using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public class ClienteModelo
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<ClienteModelo>ecliente)
            {
                ecliente.HasKey(x => x.ClienteId);
                ecliente.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                ecliente.Property(x => x.Apellido).HasColumnName("Apellido").HasMaxLength(100).IsRequired();
            }
        }
    }
}
