import React from "react";
import { Nav, Navbar as ReactstrapNavbar, NavbarBrand, NavItem, NavLink, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem, Row, Col } from "reactstrap";
import { GlobalContext } from "../context/GlobalContext";
import { useLoader } from "../../hooks/loader";
import { useNavigate } from "react-router-dom";

export const NavBar: React.FC = () => {

    const navigate = useNavigate();
    const { $user, logout } = React.useContext(GlobalContext);

    const handleLogoutClick = useLoader(async () => {
        await logout();
        navigate("/");
    });

    return (
        <ReactstrapNavbar
            full={true}
            fixed="top"
            color="light"
            className="px-3"
        >
            <NavbarBrand href="/">Build Your Head</NavbarBrand>
            <Nav className="me-auto" color="light" navbar>
                <Row>
                    <Col>
                        <NavItem>
                            <NavLink href="/products">Products</NavLink>
                        </NavItem>
                    </Col>
                    <Col>
                        <NavItem>
                            <NavLink href="/dishes">Dishes</NavLink>
                        </NavItem>
                    </Col>
                </Row>
            </Nav>
            {$user
                ? <UncontrolledDropdown inNavbar>
                    <DropdownToggle nav caret>
                        {`Hi, ${$user.name}`}
                    </DropdownToggle>
                    <DropdownMenu right>
                        <DropdownItem onClick={handleLogoutClick}>Logout</DropdownItem>
                    </DropdownMenu>
                </UncontrolledDropdown>
                : <NavLink href="/login">Log In</NavLink>
            }

        </ReactstrapNavbar>
    );
}