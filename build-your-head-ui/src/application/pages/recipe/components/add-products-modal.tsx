import { List, ListInlineItem, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"
import { Product } from "../../../../api/models"
import React from "react";
import { useLoader } from "../../../../hooks/loader";
import { GlobalContext } from "../../../context/global-context";

interface Props {
    isOpen: boolean,
    toggle: () => unknown
}

export const AddProductsModal: React.FC<Props> = ({ isOpen, toggle }) => {

    const { $api } = React.useContext(GlobalContext);

    const [products, setProducts] = React.useState<Product[]>([]);

    React.useEffect(() => {
        fetchProducts();
    }, [])

    const fetchProducts = useLoader(async () => {
        const response = await $api.Product.getAll().invoke();
        if (response.success && response.data) {
            setProducts(response.data)
        }
    })

    return (
        <Modal id="productModal" isOpen={isOpen} toggle={toggle} size="lg">
            <ModalHeader toggle={toggle}>Add Products</ModalHeader>
            <ModalBody>
                <List>
                    {products.map(product => (
                        <ListInlineItem>{product.name}</ListInlineItem>
                    ))}
                </List>
                <div>Selected products (TODO)</div>
            </ModalBody>
            <ModalFooter>
            </ModalFooter>
        </Modal>
    )
}