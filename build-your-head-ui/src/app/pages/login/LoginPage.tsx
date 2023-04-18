import React, { ChangeEvent, FormEvent } from "react";
import { Button, Col, Form, Input, Row } from "reactstrap";
import { useLoader } from "../../../hooks/loader";
import { GlobalContext } from "../../context/GlobalContext"

export const LoginPage: React.FC = () => {

    const { login } = React.useContext(GlobalContext);

    const [userName, setUserName] = React.useState("");

    const handleUserNameChange = (e: ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setUserName(value);
    }

    const handleSubmit = useLoader(async (e: FormEvent) => {
        e.preventDefault();
        await login(userName);
    })

    return (
        <Form>
            <Row>
                <Col md={3} />
                <Col md={3}>
                    <Input name="login" onChange={handleUserNameChange} />
                </Col>
                <Col md={3}>
                    <Button onClick={handleSubmit}>Log In</Button>
                </Col>
            </Row>
        </Form>
    )
}