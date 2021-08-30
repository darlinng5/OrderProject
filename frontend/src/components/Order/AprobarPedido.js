import React from "react";
import MenuGenerico from "../TopMenu/MenuGenerico";
import { useState, useEffect } from "react";
import { BaseUrl } from "../../utils/constants";
import { Button, Card, Row, Col } from "react-bootstrap";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
export default function AprobarPedido() {
  const [pedidos, getPedidos] = useState([]);

  const ApiGetAllPedidosRegistrados =
    BaseUrl + "pedidos/getallpedidosregistrados";
  useEffect(() => {
    fetch(ApiGetAllPedidosRegistrados, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((response) => getPedidos(response));
  }, []);

  
   
    function AprobarUnPedido(Id) {
      
        var Aprobarpedido ={
            id: Id
        }
        const ApiAprobarUnPedido =
        BaseUrl + "pedidos/aprobarpedidoporid";
        fetch(ApiAprobarUnPedido, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(Aprobarpedido),
      })
        
        .then((data) => {
          
            window.location.reload();
          toast.success("EXITO!!!! El  pedido se ha guardado con Exito");
        })
       
        .catch((error) => {
          toast.error("ERROR!!! Ocurrio un error al aprobar");
        });
      }

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
                              <span class="badge rounded-pill bg-warning text-dark">{items.estado}</span>
                          </Card.Text>
                          <Button  variant="primary" onClick={() => AprobarUnPedido(items.pedidoId)}>Aprobar Pedido</Button>
                      
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



