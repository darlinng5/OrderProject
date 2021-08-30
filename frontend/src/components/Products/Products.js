import React from "react";
import { Container, Row } from "react-bootstrap";
import Product from "../Product";
import Loading from "../Loading";
import DropClientes from "../Loading/DropClientes";

export default function Products(props) {
  const {
    products: { result, loading, error },
    addProductCart
  } = props;

  return (
    <Container>
      <Row>
        <DropClientes></DropClientes>
      </Row>
      <Row>
        {loading || !result ? (
          <Loading />
        ) : (
          result.map((product, index) => (
            <Product
              key={index}
              product={product}
              addProductCart={addProductCart}
            />
          ))
        )}
      </Row>
    </Container>
  );
}
