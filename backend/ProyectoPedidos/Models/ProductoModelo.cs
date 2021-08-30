using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public class ProductoModelo
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public decimal price { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<ProductoModelo>eproducto)
            {
                eproducto.HasKey(x => x.id);
                eproducto.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                eproducto.Property(x => x.Imagen).HasColumnName("Imagen");
                eproducto.Property(x => x.Descripcion).HasColumnName("Descripcion").HasMaxLength(200);
                eproducto.Property(x => x.price).HasColumnType("decimal(18,2)").HasColumnName("Precio").HasMaxLength(50).IsRequired();

            }
        }
    }
}
