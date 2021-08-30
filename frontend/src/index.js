import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import * as serviceWorker from "./serviceWorker";
import "bootstrap/dist/css/bootstrap.min.css";
import "react-toastify/dist/ReactToastify.css";
import {BrowserRouter, Route} from "react-router-dom";
import AprobarPedido from "./components/Order/AprobarPedido";
import ListarPedidosRegistrados from "./components/Order/ListarPedidosRegistrados";
import ListarPedidosAprobados from "./components/Order/ListarPedidosAprobados";

ReactDOM.render(
    <BrowserRouter>
        <Route exact path="/" component={App}/>
        <Route exact path="/listar" component={ListarPedidosRegistrados}/>
        <Route exact path="/aprobar" component={AprobarPedido}/>
        <Route exact path="/listaraprobados" component={ListarPedidosAprobados}/>
    </BrowserRouter>,
document.getElementById("root"));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
