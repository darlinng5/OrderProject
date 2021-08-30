using Microsoft.EntityFrameworkCore;
using ProyectoPedidos.DataContext;
using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Services
{
    public class ProductoService
    {
        ProyectoDBContext _context;

        public ProductoService(ProyectoDBContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<ProductoModelo>> GetAllProductos()
        {
            return await _context.Producto.ToListAsync();
        }

    }
}
