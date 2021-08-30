import React from "react";
import MenuGenerico from "../TopMenu/MenuGenerico";
import { useState, useEffect } from "react";
import { BaseUrl } from "../../utils/constants";
import { Button, Card, Row, Col } from "react-bootstrap";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";



export default function ListarPedidosAprobados() {
  const [pedidos, getPedidos] = useState([]);

  var BuscarPedidoRegistradoFiltrado ={
    PedidoId:12,
    ClienteId:2,
    FehaRegistro:""
}


  const ApiGetAllPedidosAprobados =
    BaseUrl + "pedidos/getallpedidosaprobados";
  useEffect(() => {
    fetch(ApiGetAllPedidosAprobados, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((response) => getPedidos(response));
  }, []);

  
   
   

  return (
    <React.Fragment>
      <MenuGenerico></MenuGenerico>
      <Row>
          <Col md={2}></Col>
          <Col md={8}>
          {
                  pedidos.map((items, index)=>{
                   
                     return(
                     
                        <Card>
                        <Card as="h5"> <strong>Pedido #</strong> {items.pedidoId}</Card>
                        <Card.Body>
                          <Card.Title><strong>Cliente:</strong> {items.cliente.nombre}{" "} {items.cliente.apellido}</Card.Title>
                          <Card.Text>
                              <h5><strong>Vendedor: {items.vendedor.nombre}{" "} {items.cliente.apellido} </strong></h5>
                              <span class="badge badge rounded-pill bg-success">{items.pedidoFecha}</span>
                              <span class="badge rounded-pill bg-success text-dark">{items.estado}</span>
                          </Card.Text>
                          <Card.Text>
                            <center><h3>Detalle del pedido</h3></center>
                              {items.pedidoItems.map((ipedido, i)=>{
                                return(
                                  <div>
                                    <h4><strong>Linea:  </strong> <span class="badge badge-info"> {i+1}</span></h4>
                                    <h5><strong>Id: </strong> {ipedido.pedidoItemId}</h5>
                                    <h5><strong>Producto: </strong>{ipedido.productoNombre}</h5>
                                    <h5><strong>Precio: </strong>{ipedido.precio}</h5>
                                    <h5><strong>Cantidad: </strong>{ipedido.cantidad}</h5>
                                  </div>
                                )
                              })}

                          </Card.Text>
                             
                            {console.log(items.pedidoItems)}
                        </Card.Body>
                      </Card>
                     )
                  })
              }

          </Col>
          <Col md={2}></Col>
      </Row>
                
    </React.Fragment>
  );
}


