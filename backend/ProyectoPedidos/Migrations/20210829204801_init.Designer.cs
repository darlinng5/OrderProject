﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPedidos.DataContext;

namespace ProyectoPedidos.Migrations
{
    [DbContext(typeof(ProyectoDBContext))]
    [Migration("20210829204801_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoPedidos.Models.ClienteModelo", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Apellido")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("Apellido");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.PedidoItemModelo", b =>
                {
                    b.Property<int>("PedidoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("ProductoCantidad");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ProductoPrecio");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<string>("ProductoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PedidoItemId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.PedidoOrdenModelo", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Estado");

                    b.Property<DateTime>("PedidoFecha")
                        .HasColumnType("datetime")
                        .HasColumnName("FechaRegistro");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.ProductoModelo", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion1");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Descripcion");

                    b.Property<decimal>("Precio")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Nombre");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.SupervisorModelo", b =>
                {
                    b.Property<int>("SupervisorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Apellido")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("Apellido");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("SupervisorId");

                    b.ToTable("Supervisor");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.VendedorModelo", b =>
                {
                    b.Property<int>("VendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Apellido")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendedorId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.PedidoItemModelo", b =>
                {
                    b.HasOne("ProyectoPedidos.Models.PedidoOrdenModelo", "Pedido")
                        .WithMany("PedidoItems")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoPedidos.Models.ProductoModelo", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.PedidoOrdenModelo", b =>
                {
                    b.HasOne("ProyectoPedidos.Models.ClienteModelo", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoPedidos.Models.VendedorModelo", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("ProyectoPedidos.Models.PedidoOrdenModelo", b =>
                {
                    b.Navigation("PedidoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
