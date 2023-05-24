import { Button, List, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { Product } from "../../../../api/models"
import React from "react";
import { ProductsSearch } from "./products-search";

interface Props {
    isOpen: boolean,
    toggle: () => unknown,
    onSubmit: (products: Product[]) => unknown
}

export const AddProductsModal: React.FC<Props> = ({ isOpen, toggle, onSubmit }) => {

    const [products, setProducts] = React.useState<Product[]>([])

    const addProduct = (product: Product) => {
        setProducts(prev => {
            const newProducts = [...prev];
            newProducts.push(product);
            return newProducts;
        })
    }

    const handleAddProductsClick = () => {
        onSubmit(products);
    }

    return (
        <Modal id="productModal" isOpen={isOpen} toggle={toggle} size="lg">
            <ModalHeader toggle={toggle}>Add Products</ModalHeader>
            <ModalBody>
                <ProductsSearch onAdd={addProduct} />
                <hr />
                <List>
                    {products.map(p => (
                        <li key={p.id}>{p.name}</li>
                    ))}
                </List>
            </ModalBody>
            <ModalFooter>
                <Button color="success" onClick={handleAddProductsClick}>Add Products</Button>
            </ModalFooter>
        </Modal>
    )
}