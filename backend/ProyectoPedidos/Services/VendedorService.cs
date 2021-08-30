using Microsoft.EntityFrameworkCore;
using ProyectoPedidos.DataContext;
using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Services
{
    public class VendedorService
    {
        ProyectoDBContext _context;

        public VendedorService(ProyectoDBContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<VendedorModelo>> GetAllVendedores()
        {
            return await _context.Vendedor.ToListAsync();
        }
    }
}
