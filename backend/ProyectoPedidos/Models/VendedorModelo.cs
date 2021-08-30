using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public class VendedorModelo
    {
        [Key]
        public int VendedorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<VendedorModelo> evendedor)
            {
                evendedor.HasKey(x => x.VendedorId);
                evendedor.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                evendedor.Property(x => x.Apellido).HasColumnName("Apellido").HasMaxLength(100).IsRequired();
            }
        }
    }
}
