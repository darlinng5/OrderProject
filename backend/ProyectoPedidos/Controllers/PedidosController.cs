using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPedidos.DTOs;
using ProyectoPedidos.Models;
using ProyectoPedidos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidos()
        {
            return await _pedidoService.GetAllPedidos();
        }

       


        [HttpGet]
        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidosRegistrados()
        {
            return await _pedidoService.GetAllPedidosOrdenRegistrados();
        }



       [HttpPost]
        public async Task<ActionResult> AprobarPedidoPorId(AprobarPedido pedido)
        {
            string mensaje = await _pedidoService.AprobarPedidoPorId(pedido.id);
            if (mensaje==null)
            {
                return Ok();
            }
            return BadRequest(mensaje);
        }


        [HttpGet]
        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidosAprobados()
        {
            return await _pedidoService.GetAllPedidosOrdenAprobados();
        }
        [HttpPost]
        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidosRegistradosFiltrados(BuscarPedidoRegistradoFiltrado buscarPedidoRegistradoFiltrado)
        {
            return await _pedidoService.GetAllPedidosOrdenRegistradosFiltrados(buscarPedidoRegistradoFiltrado);
        }



        [HttpPost]
        public async Task<ActionResult<PedidoOrdenModelo>> AddNuevoPedidoOrden(List<PedidoAgregarDTO> ordenCompraDto)
        {
            string mensaje = await _pedidoService.AddNuevoPedido(ordenCompraDto);
            if (mensaje==null)
            {
                return Ok("Se ha agregado el nuevo pedido con exito");
            }

            return BadRequest(mensaje);
        }

    }
}
