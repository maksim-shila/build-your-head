import React from "react";
import { Button, Form, FormGroup, Input, Label, Col, Row, InputGroup, ModalHeader, ModalBody, Modal, ModalFooter } from "reactstrap";
import $api, { Product } from "../api/api-client";
import { useLoader } from "../hooks/loader";
import { AvatarUpload } from "./avatar-upload";

interface ProductViewModalProps {
    isOpen: boolean,
    product: Product | null,
    toggle: () => void,
    onSubmit: (product: Product) => Promise<unknown>,
    onClose: () => unknown
}

const defaults: Product = {
    name: "",
    description: "",
    proteins: 0,
    carbohydrates: 0,
    fats: 0,
    nutrition: 0
}

export const ProductViewModal: React.FC<ProductViewModalProps> = ({ isOpen, product, toggle, onSubmit, onClose }) => {

    const isEditMode = product !== null;

    const [name, setName] = React.useState<string>(defaults.name);
    const [description, setDescription] = React.useState<string>(defaults.description);
    const [carbohydrates, setCarbohydrates] = React.useState<number>(defaults.carbohydrates);
    const [proteins, setProteins] = React.useState<number>(defaults.proteins);
    const [fats, setFats] = React.useState<number>(defaults.fats);
    const [nutrition, setNutrition] = React.useState<number>(defaults.nutrition);

    const [currentImage, setCurrentImage] = React.useState<string | null>(null);
    const [image, setImage] = React.useState<Blob | null>(null);

    React.useEffect(() => {
        if (!isOpen || product === null) {
            return;
        }

        fillProductData(product);
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [isOpen, product]);

    const fillProductData = useLoader(async (product: Product) => {
        if (!product.id) {
            return;
        }

        setName(product.name);
        setDescription(product.description);
        setCarbohydrates(product.carbohydrates);
        setProteins(product.proteins);
        setFats(product.fats);
        setNutrition(product.nutrition);

        const response = await $api.Product.getPrimaryImage(product.id);
        if (response.data) {
            setCurrentImage(response.data);
        }
    });

    const reset = () => {
        setName(defaults.name);
        setDescription(defaults.description);
        setCarbohydrates(defaults.carbohydrates);
        setProteins(defaults.proteins);
        setFats(defaults.fats);
        setNutrition(defaults.nutrition);

        setImage(null);
        setCurrentImage(null);
    }

    const handleSubmit = useLoader(async (event: React.FormEvent) => {
        event.preventDefault();
        const updatedProduct = { id: product?.id, name, description, proteins, carbohydrates, fats, nutrition };
        const updateProductResponse = await (isEditMode ? $api.Product.post(updatedProduct) : $api.Product.put(updatedProduct));
        const updatedProductId = updateProductResponse.data?.id;
        if (!updatedProductId) {
            console.error(`Failed to ${isEditMode ? "update" : "create"} product`);
            return;
        }
        if (image != null) {
            const uploadImageResult = await $api.Image.post(image);
            const imageId = uploadImageResult.data;
            if (!imageId) {
                console.error("Failed to upload image");
            } else {
                await $api.Product.attachImage(updatedProductId, imageId, true);
            }
        }

        await onSubmit(updateProductResponse.data);
        reset();
    });

    const calculateNutrition = () => {
        const nutrition = proteins * 4 + carbohydrates * 4 + fats * 9;
        setNutrition(nutrition);
    }

    return (
        <div>
            <Modal
                isOpen={isOpen}
                onClosed={() => { onClose(); reset(); }}
                toggle={toggle}
                size="lg"
            >
                <ModalHeader toggle={toggle}>Add Product</ModalHeader>
                <ModalBody>
                    <Form onSubmit={handleSubmit}>
                        <Row>
                            <Col md={4}>
                                <AvatarUpload imageBase64={currentImage} onUpload={image => setImage(image)} />
                            </Col>
                            <Col>
                                <FormGroup>
                                    <Label for="name">Name:</Label>
                                    <Input
                                        id="name"
                                        name="name"
                                        autoComplete="off"
                                        value={name}
                                        onChange={e => setName(e.target.value)}
                                    />
                                </FormGroup>
                                <FormGroup>
                                    <Label for="description">Description:</Label>
                                    <textarea
                                        id="description"
                                        name="description"
                                        className="textarea form-control"
                                        rows={6}
                                        value={description}
                                        onChange={e => setDescription(e.target.value)}
                                    />
                                </FormGroup>
                            </Col>
                        </Row>

                        <Row>
                            <Col md={2}>
                                <Label for="carbohydrates">Carbs:</Label>
                                <Input
                                    id="carbohydrates"
                                    name="carbohydrates"
                                    type="number"
                                    value={carbohydrates}
                                    onChange={e => setCarbohydrates(Number(e.target.value))}
                                />
                            </Col>
                            <Col md={2}>
                                <Label for="proteins">Proteins:</Label>
                                <Input
                                    id="proteins"
                                    name="proteins"
                                    type="number"
                                    value={proteins}
                                    onChange={e => setProteins(Number(e.target.value))}
                                />
                            </Col>
                            <Col md={2}>
                                <Label for="fats">Fats:</Label>
                                <Input
                                    name="fats"
                                    id="fats"
                                    type="number"
                                    value={fats}
                                    onChange={e => setFats(Number(e.target.value))}
                                />
                            </Col>
                            <Col md={2} />
                            <Col md={4}>
                                <Label for="nutrition">Nutrition:</Label>
                                <InputGroup>
                                    <Input
                                        name="nutrition"
                                        id="nutrition"
                                        type="number"
                                        value={nutrition}
                                        onChange={e => setNutrition(Number(e.target.value))}
                                    />
                                    <Button onClick={calculateNutrition}>Calculate</Button>
                                </InputGroup>
                            </Col>
                        </Row>
                    </Form>
                </ModalBody>
                <ModalFooter>
                    <Button className="btn-success mt-4" onClick={handleSubmit}>{product ? "Update" : "Add"}</Button>
                </ModalFooter>
            </Modal>
        </div>
    );
}