import React from "react";
import { Container, Navbar, Nav } from "react-bootstrap";
import Cart from "../Cart";
import "./TopMenu.scss";

export default function TopMenu(props) {
  const { productsCart, getProductsCart, products } = props;

  return (
    <Navbar bg="dark" variant="dark" className="top-menu">
      <Container>
        
         <MenuNav /> 
        <Cart
          productsCart={productsCart}
          getProductsCart={getProductsCart}
          products={products}
        />
      </Container>
    </Navbar>
  );
}



function MenuNav() {
  return (
    <Nav className="mr-auto">
      <Nav.Link href="/">Inicio</Nav.Link>
      <Nav.Link href="/aprobar">Aprobar Pedido</Nav.Link>
      <Nav.Link href="/listar">Listar Registrados</Nav.Link>
      <Nav.Link href="/listaraprobados">Listar Aprobados</Nav.Link>
    </Nav>
  );
}
