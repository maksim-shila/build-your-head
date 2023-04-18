import React from "react";
import { Nav, Navbar as ReactstrapNavbar, NavbarBrand, NavbarText, NavItem, NavLink } from "reactstrap";
import { GlobalContext } from "../context/GlobalContext";

export const NavBar: React.FC = () => {

    const { $user } = React.useContext(GlobalContext);

    return (
        <ReactstrapNavbar
            full={true}
            fixed="top"
            color="light"
            className="px-3"
        >
            <NavbarBrand href="/">Build Your Head</NavbarBrand>
            <Nav className="me-auto" color="light" navbar>
                <NavItem>
                    <NavLink href="/products">Products</NavLink>
                </NavItem>
            </Nav>
            {$user
                ? <NavbarText>{`Hi, ${$user.name}`}</NavbarText>
                : <NavLink href="/login">Log In</NavLink>
            }

        </ReactstrapNavbar>
    );
}