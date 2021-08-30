using Microsoft.EntityFrameworkCore;
using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.DataContext
{
    public class ProyectoDBContext : DbContext
    {

        public ProyectoDBContext(DbContextOptions options) : base(options)
        {

        }


        public virtual DbSet<ClienteModelo> Cliente { get; set; }
        public virtual DbSet<PedidoItemModelo> PedidoItem { get; set; }
        public virtual DbSet<PedidoOrdenModelo> Pedido { get; set; }

        public virtual DbSet<ProductoModelo> Producto { get; set; }

        public virtual DbSet<SupervisorModelo> Supervisor { get; set; }
        public virtual DbSet<VendedorModelo> Vendedor { get; set; }
        public virtual DbSet<PedidoAprobacionControl> PedidoArprobacionControl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelB)
        {

            new ClienteModelo.Map(modelB.Entity<ClienteModelo>());
            new PedidoItemModelo.Map(modelB.Entity<PedidoItemModelo>());
            new PedidoOrdenModelo.Map(modelB.Entity<PedidoOrdenModelo>());
            new ProductoModelo.Map(modelB.Entity<ProductoModelo>());
            new SupervisorModelo.Map(modelB.Entity<SupervisorModelo>());
            new SupervisorModelo.Map(modelB.Entity<SupervisorModelo>());

            new PedidoAprobacionControl.Map(modelB.Entity<PedidoAprobacionControl>());


            foreach (var relationship in modelB.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelB);

        }


    }
}
