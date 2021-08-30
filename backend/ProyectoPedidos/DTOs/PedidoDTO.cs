using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.DTOs
{
    public class PedidoDTO
    {
        public int PedidoId { get; set; }

        public int ClienteId { get; set; }

        public string ClienteNombre { get; set; }
        public int VendedorId { get; set; }

        public string VendedorNombre { get; set; }



        public IReadOnlyList<PedidoItemModelo> PedidoItems { get; set; }


        public string PedidoEstado { get; set; }
        public DateTime PedidoFecha { get; set; }
    }
}
