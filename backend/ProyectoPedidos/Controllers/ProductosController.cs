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
    public class ProductosController : ControllerBase
    {

      ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }



        [HttpGet]
        public async Task<IReadOnlyList<ProductoModelo>> GetAllProductos()
        {
            return await _productoService.GetAllProductos();
        }
    }
}
