import React from "react";
import { Button } from "reactstrap";
import $api, { Product } from "./api/api-client";
import { ProductViewModal } from "./components/product-view-modal";
import { ProductsList } from "./components/products-list";
import { useLoader } from "./hooks/loader";

export const Home = () => {
    const [products, setProducts] = React.useState<Product[]>([]);
    const [showProductDialog, setShowProductDialog] = React.useState(false);
    const [product, setProduct] = React.useState<Product | null>(null);

    React.useEffect(() => {
        fetchProducts();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const fetchProducts = useLoader(async () => {
        const response = await $api.Product.getAll();
        setProducts(response.data);
    });

    const toggleProductDialog = () => setShowProductDialog(!showProductDialog);

    const editProduct = (product: Product) => {
        setProduct(product);
        setShowProductDialog(true);
    }

    const deleteProduct = useLoader(async (product: Product) => {
        if (!product.id) {
            console.error("Couldn't delete product since it hasn't id");
            return;
        }
        await $api.Product.delete(product.id);
        await fetchProducts();
    });

    return (
        <div>
            <Button onClick={toggleProductDialog}>Add Product</Button>
            <div className="mt-3">
                <ProductsList
                    products={products}
                    onEdit={editProduct}
                    onDelete={deleteProduct}
                />
            </div>
            <ProductViewModal
                isOpen={showProductDialog}
                product={product}
                toggle={toggleProductDialog}
                onSubmit={async () => {
                    setShowProductDialog(false);
                    setProduct(null);
                    await fetchProducts();
                }}
                onClose={() => setProduct(null)}
            />
        </div>
    );
}