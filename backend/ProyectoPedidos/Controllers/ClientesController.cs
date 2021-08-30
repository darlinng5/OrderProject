using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ClientesController : ControllerBase
    {

        ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }



        [HttpGet]
        public async Task<IReadOnlyList<ClienteModelo>> GetAllClientes()
        {
            return await _clienteService.GetAllClientes();
        }
    }
}
