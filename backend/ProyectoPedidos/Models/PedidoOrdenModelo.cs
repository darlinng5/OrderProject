using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public class PedidoOrdenModelo
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public string Estado { get; set; } = Helper.EstadoPedidoRegistrado;
        public DateTime PedidoFecha { get; set; } = DateTime.Now;
        public ClienteModelo Cliente { get; set; }
        public VendedorModelo Vendedor { get; set; }

        public IReadOnlyList<PedidoItemModelo>PedidoItems { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<PedidoOrdenModelo>epedido)
            {
                epedido.HasKey(x => x.PedidoId);
                epedido.Property(x => x.Estado).HasColumnName("Estado").HasMaxLength(50).IsRequired();
                epedido.Property(x => x.PedidoFecha).HasColumnType("datetime").HasColumnName("FechaRegistro");

            }





        }

        
    }
}
