import React from "react";
import { Col, Card, Button } from "react-bootstrap";
import { BASE_PATH } from "../../utils/constants";

import "./Product.scss";

export default function Product(props) {
  const { product, addProductCart } = props;

  return (
    <Col xs={3} className="product">
      <Card>
        <Card.Img variant="top" src={product.imagen} />
        <Card.Body>
          <Card.Title>{product.name}</Card.Title>
          <Card.Text>{product.descripcion}</Card.Text>
          <Card.Text>{product.price.toFixed(2)} L / Unidad</Card.Text>
          <Button onClick={() => addProductCart(product.id, product.nombre)}>
            Añadir al carrito
          </Button>
        </Card.Body>
      </Card>
    </Col>
  );
}
