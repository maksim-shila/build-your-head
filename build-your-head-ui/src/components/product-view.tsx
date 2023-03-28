import React from "react";
import { Button, Form, FormGroup, Input, Label, Col, Row, InputGroup } from "reactstrap";
import $api from "../api/api-client";

export const ProductView = () => {

    const [name, setName] = React.useState("");
    const [description, setDescription] = React.useState("");
    const [proteins, setProteins] = React.useState(0);
    const [carbohydrates, setCarbohydrates] = React.useState(0);
    const [fats, setFats] = React.useState(0);
    const [nutrition, setNutrition] = React.useState(0);

    const onSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        console.log(await $api.Product.get(1));
        console.log({ name, description });
    }

    const calculateNutrition = () => {
        const nutrition = proteins * 4 + carbohydrates * 4 + fats * 9;
        setNutrition(nutrition);
    }

    return <div>
        <Form onSubmit={onSubmit}>
            <FormGroup>
                <Label for="name">Product Name:</Label>
                <Input
                    id="name"
                    name="name"
                    autoComplete="off"
                    value={name}
                    onChange={e => setName(e.target.value)}
                />
            </FormGroup>
            <FormGroup>
                <Label for="description">Product Description:</Label>
                <Input
                    id="description"
                    name="description"
                    type="textarea"
                    value={description}
                    onChange={e => setDescription(e.target.value)}
                />
            </FormGroup>
            <Row>
                <Col md={2}>
                    <Label for="carbohydrates">Carbohydrates:</Label>
                    <Input
                        id="carbohydrates"
                        name="carbohydrates"
                        type="number"
                        className="w-75"
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
                        className="w-75"
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
                        className="w-75"
                        value={fats}
                        onChange={e => setFats(Number(e.target.value))}
                    />
                </Col>
                <Col md={1} />
                <Col md={2}>
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

            <Button type="submit" className="btn-success mt-4">Submit</Button>
        </Form>
    </div>;
}