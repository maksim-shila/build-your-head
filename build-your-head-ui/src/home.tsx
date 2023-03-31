import React from "react";
import { Button } from "reactstrap";
import $api, { Product } from "./api/api-client";
import { ProductViewModal } from "./components/product-view-modal";
import { ProductsList } from "./components/products-list";
import { useLoader } from "./hooks/loader";

export const Home = () => {
    const [products, setProducts] = React.useState<Product[]>([]);
    const [showProductDialog, setShowProductDialog] = React.useState(false);

    React.useEffect(() => {
        fetchProducts();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const fetchProducts = useLoader(async () => {
        const response = await $api.Product.getAll();
        setProducts(response.data);
    });

    const toggleProductDialog = () => setShowProductDialog(!showProductDialog);

    return (
        <div>
            <Button onClick={toggleProductDialog}>Add Product</Button>
            <div className="mt-3">
                <ProductsList products={products} />
            </div>
            <ProductViewModal
                isOpen={showProductDialog}
                toggle={toggleProductDialog}
                onChange={async () => {
                    setShowProductDialog(false);
                    await fetchProducts();
                }}
            />
        </div>
    );
}