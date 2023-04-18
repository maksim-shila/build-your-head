import React from "react"
import { Button } from "reactstrap";
import { Product } from "../../../api/api-client";
import { useLoader } from "../../../hooks/loader";
import { GlobalContext } from "../../context/GlobalContext";
import { ProductFormData } from "./components/product-form";
import { ProductViewModal } from "./components/product-view-modal";
import { ProductsList } from "./components/products-list"

export const ProductsPage: React.FC = () => {

    const { $api, $user } = React.useContext(GlobalContext);

    const [products, setProducts] = React.useState<Product[]>([]);

    const [isProductViewModalOpen, setIsProductViewModalOpen] = React.useState(false);
    const [activeProduct, setActiveProduct] = React.useState<Product | null>(null);

    React.useEffect(() => {
        fetchProducts();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [$user]);

    const fetchProducts = useLoader(async (): Promise<void> => {
        const response = await $api.Product.getAll();
        setProducts(response.data);
    })

    const showProductViewModal = (product: Product | null) => {
        setActiveProduct(product);
        setIsProductViewModalOpen(true);
    }

    const toggleProductViewModal = () => {
        if (isProductViewModalOpen) {
            setActiveProduct(null);
        }
        setIsProductViewModalOpen(!isProductViewModalOpen);
    }

    const handleSubmit = async (data: ProductFormData) => {
        const isEdit = activeProduct !== null;
        if (isEdit && !activeProduct.id) {
            console.error("Edited product hasn't id");
            return;
        }

        const { imageBase64, imageChanged, ...product } = data;
        const response = await (isEdit ? $api.Product.post(activeProduct.id!, product) : $api.Product.put(product));
        const productId = response.data?.id;
        if (!productId) {
            console.error(`Failed to ${isEdit ? "update" : "create"} product`);
            return;
        }
        if (imageChanged && imageBase64) {
            await postImage(productId, imageBase64);
        }

        setActiveProduct(null);
        setIsProductViewModalOpen(false);
        await fetchProducts();
    }

    const postImage = async (productId: number, imageBase64: string): Promise<void> => {
        const response = await $api.Image.post(imageBase64);
        const imagePath = response.data;
        if (!imagePath) {
            console.error("Failed to upload image");
            return;
        }

        await $api.Product.attachImage({ productId, imagePath, primary: true });
    }

    const deleteProduct = async (product: Product) => {
        if (!product.id) {
            console.error("Couldn't delete product without id");
            return;
        }
        await $api.Product.delete(product.id);
        await fetchProducts();
    }

    return (
        <React.Fragment>
            <Button onClick={() => showProductViewModal(null)}>Add Product</Button>
            <ProductsList
                products={products}
                onEdit={showProductViewModal}
                onDelete={deleteProduct}
            />
            <ProductViewModal
                isOpen={isProductViewModalOpen}
                toggle={toggleProductViewModal}
                product={activeProduct}
                onSubmit={handleSubmit}
            />
        </React.Fragment>
    )
}