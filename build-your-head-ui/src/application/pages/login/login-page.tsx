import React, { ChangeEvent, FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Col, Form, Input, Row } from "reactstrap";
import { useLoader } from "../../../hooks/loader";
import { GlobalContext } from "../../context/global-context"
import { useTitle } from "../../../hooks/use-title";

export const LoginPage: React.FC = (props) => {

    useTitle("Login");

    const navigate = useNavigate();
    const { login } = React.useContext(GlobalContext);
    const [userName, setUserName] = React.useState("");

    const handleUserNameChange = (e: ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setUserName(value);
    }

    const handleSubmit = useLoader(async (e: FormEvent) => {
        e.preventDefault();
        await login(userName);
        navigate("/");
    })

    return (
        <Form onSubmit={handleSubmit}>
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