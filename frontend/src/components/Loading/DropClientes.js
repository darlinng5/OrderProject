import React from "react";
import { Container, Dropdown, DropdownButton, Row, Spinner } from "react-bootstrap";
import { useState, useEffect } from "react";
import { BaseUrl } from "../../utils/constants";
import "./Loading.scss";
import { Col } from "react-bootstrap";
import { STORAGE_CLIENTE } from "../../utils/constants";
import { STORAGE_VENDEDOR } from "../../utils/constants";



export default function DropClientes() {
    

    const ApiGetAllClientes=BaseUrl+"clientes/getallclientes"
    const ApiGetAllVendedores=BaseUrl+"vendedores/getallvendedores"
    const [clientes, getClientes] = useState([]);
    const [vendedores, getVendedores] = useState([]);
    const [output, setData] = useState([]);
    const [outputVendedores, setDataVendedores] = useState([]);
    useEffect(() => {
      fetch(ApiGetAllClientes,{
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        }
  
      })
      .then(response => response.json())
      .then(response => getClientes(response))
  
    },[])

    useEffect(() => {
        fetch(ApiGetAllVendedores,{
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          }
    
        })
        .then(response => response.json())
        .then(response => getVendedores(response))
    
      },[])





    const handleSelect=(e)=>{
     
       setData(e)
       localStorage.setItem(STORAGE_CLIENTE, e);
       
       
      }
      const handleSelectVendedores=(e)=>{
     
        setDataVendedores(e)
        localStorage.setItem(STORAGE_VENDEDOR, e);
        
       }
 
      
     

  return (
    <div>
        <Container fluid>


       
        <Row>
                <Col>
                Seleccione un Cliente
                </Col>
                <Col>
                Seleccione un Vendedor
                </Col>
        </Row>
        <Row>
        <Col>
                     
          <DropdownButton  id="drop-basic" title={"-----"+output+"------"} onSelect={handleSelect}>
              {
                  clientes.map((items, index)=>{
                     return(
                         <Dropdown.Item key={index} eventKey={items.clienteId}>{items.nombre}</Dropdown.Item>
                     )
                  })
              }
         </DropdownButton>  
            </Col>
            <Col>
            <DropdownButton  id="drop-vendedores" title={"-----"+outputVendedores+"------"} onSelect={handleSelectVendedores}>
              {
                  vendedores.map((items, index)=>{
                     return(
                         <Dropdown.Item key={index} eventKey={items.vendedorId}>{items.nombre}</Dropdown.Item>
                     )
                  })
              }
         </DropdownButton>
            </Col>
        </Row>

   
        </Container>
    </div>
  );
}