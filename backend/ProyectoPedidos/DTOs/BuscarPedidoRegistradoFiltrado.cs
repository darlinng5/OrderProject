using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.DTOs
{
    public class BuscarPedidoRegistradoFiltrado
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
