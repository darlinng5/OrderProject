using Microsoft.EntityFrameworkCore;
using ProyectoPedidos.DataContext;
using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Services
{

    
    public class ClienteService
    {
       ProyectoDBContext _context;

        public ClienteService(ProyectoDBContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<ClienteModelo>> GetAllClientes()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
