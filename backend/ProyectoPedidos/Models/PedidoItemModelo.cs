using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public class PedidoItemModelo
    {
        public int PedidoItemId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public Decimal Precio { get; set; }
        public int Cantidad { get; set; }

        [JsonIgnore]
        public PedidoOrdenModelo Pedido { get; set; }
        public ProductoModelo Producto { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<PedidoItemModelo>epedidoitem)
            {
                epedidoitem.HasKey(x => x.PedidoItemId);
                epedidoitem.Property(x => x.Precio).HasColumnName("ProductoPrecio").HasColumnType("decimal(18,2)").IsRequired();
                epedidoitem.Property(x => x.Cantidad).HasColumnName("ProductoCantidad").IsRequired();
                epedidoitem.HasOne(x => x.Pedido).WithMany(x => x.PedidoItems).HasForeignKey(x => x.PedidoId);

            }
        }
    }
}
