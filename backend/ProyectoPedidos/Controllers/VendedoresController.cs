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
    public class VendedoresController : ControllerBase
    {

       VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }



        [HttpGet]
        public async Task<IReadOnlyList<VendedorModelo>> GetAllVendedores()
        {
            return await _vendedorService.GetAllVendedores();
        }
    }
}
