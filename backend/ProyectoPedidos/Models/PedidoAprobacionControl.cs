using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public class PedidoAprobacionControl
    {
        public int PedidoAprobacionControlId { get; set; }
        public DateTime AprobacionFecha { get; set; } = DateTime.Now;
        public PedidoOrdenModelo PedidoOrden { get; set; }
        public int PedidoId { get; set; }

        public int SupervisorId { get; set; }
        public SupervisorModelo Supervisor { get; set; }



        public class Map
        {
            public Map(EntityTypeBuilder<PedidoAprobacionControl> epedido)
            {

                epedido.HasKey(x => x.PedidoAprobacionControlId);
                epedido.Property(x => x.AprobacionFecha).HasColumnType("datetime").HasColumnName("FechaAprobacion").IsRequired();

            }
        }
    }
}
