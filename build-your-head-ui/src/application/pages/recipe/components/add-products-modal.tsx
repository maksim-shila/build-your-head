import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"

interface Props {
    isOpen: boolean,
    toggle: () => unknown
}

export const AddProductsModal: React.FC<Props> = ({ isOpen, toggle }) => {
    return (
        <Modal id="productModal" isOpen={isOpen} toggle={toggle} size="lg">
            <ModalHeader toggle={toggle}>Add Products</ModalHeader>
            <ModalBody>
                <div>List of products (TODO)</div>
                <div>Selected products (TODO)</div>
            </ModalBody>
            <ModalFooter>
            </ModalFooter>
        </Modal>
    )
}