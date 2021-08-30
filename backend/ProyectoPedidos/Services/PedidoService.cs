using Microsoft.EntityFrameworkCore;
using ProyectoPedidos.DataContext;
using ProyectoPedidos.Domains;
using ProyectoPedidos.DTOs;
using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Services
{
    public class PedidoService
    {
        ProyectoDBContext _context;
        PedidoDomain _pedidoDomain;

        public PedidoService(ProyectoDBContext context, PedidoDomain pedidoDomain)
        {
            _context = context;
            _pedidoDomain = pedidoDomain;
        }


        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidos()
        {
            return await _context.Pedido
                    .Include(p => p.Cliente)
                    .Include(p => p.Vendedor)
                    .Include(p => p.PedidoItems)
                    .ToListAsync();

        }



        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidosOrdenRegistrados()
        {
            return await _context.Pedido
                    .Include(p => p.Cliente)
                    .Include(p => p.Vendedor)
                    .Include(p => p.PedidoItems)
                    .OrderByDescending(x=>x.PedidoId)
                    .Where(x => x.Estado.Equals(Helper.EstadoPedidoRegistrado))
                    .ToListAsync();
        }



        public async Task<string> AprobarPedidoPorId(int Id)
        {
            var pedidoAprobar = _context.Pedido.Find(Id);
            string comprobarPedido = _pedidoDomain.ComprobarPedido(pedidoAprobar);
            if (comprobarPedido != null)
            {
                return comprobarPedido;
            }

            PedidoAprobacionControl pedidoAprobacion = new PedidoAprobacionControl();
            pedidoAprobacion.PedidoId = pedidoAprobar.PedidoId;
            pedidoAprobacion.SupervisorId = 1;//SE DEBE CAMBIAR PARA QUE SEA DINAMICO
            pedidoAprobar.Estado = Helper.EstadoPedidoAprobado;
            await _context.PedidoArprobacionControl.AddAsync(pedidoAprobacion);

            if (await _context.SaveChangesAsync() > 0)
            {
                return null;
            }



            return "Se presento un problema a la hora de insertar los datos";
        }



        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidosOrdenAprobados()
        {



            return await _context.Pedido
                    .Include(p => p.Cliente)
                    .Include(p => p.Vendedor)
                    .Include(p => p.PedidoItems)
                    .OrderByDescending(x=>x.PedidoId)
                    .Where(x => x.Estado.Equals(Helper.EstadoPedidoAprobado))
                    .ToListAsync();
        }

        public async Task<IReadOnlyList<PedidoOrdenModelo>> GetAllPedidosOrdenRegistradosFiltrados(BuscarPedidoRegistradoFiltrado buscarPedidoRegistradoFiltrado)
        {

            return await _context.Pedido
                .Include(p=>p.Cliente)
                .Include(p=>p.Vendedor)
                .Include(p=>p.PedidoItems)
                .Where(
                x => x.Estado == Helper.EstadoPedidoRegistrado &&
                (x.PedidoFecha == buscarPedidoRegistradoFiltrado.FechaRegistro||
                x.ClienteId == buscarPedidoRegistradoFiltrado.ClienteId ||
                x.PedidoId == buscarPedidoRegistradoFiltrado.PedidoId))
                .ToListAsync();


          
        }



      





        public async Task<string> AddNuevoPedido(List<PedidoAgregarDTO> pedidoAgregarDto)
        {
            string mensajePedidoAgregar = _pedidoDomain.ComprobarParaRegistrarPedido(pedidoAgregarDto);
            if (mensajePedidoAgregar != null)
            {
                return mensajePedidoAgregar;
            }

            var cliente = await _context.Cliente.FindAsync(pedidoAgregarDto[Helper.IndiceSiExisteClienteParaAgregarPedido].Id);
            var vendedor = await _context.Vendedor.FindAsync(pedidoAgregarDto[Helper.IndiceSiExisteVendedorParaAgregarPedido].Id);
            if (cliente == null || vendedor == null)
            {
                return "El Cliente o el Vendedor no estan registrados aun";

            }


            for (int i = Helper.IndiceParaEmpezarAIterarSobreProductos; i < pedidoAgregarDto.Count; i++)
            {
                var existeProducto = _context.Producto.Find(pedidoAgregarDto[i].Id);
                if (existeProducto == null)
                {
                    return "No se puedo encontrar un producto en la base de datos";

                }
            }
            string respuesta = GuardarPedidoEnBaseDatos(pedidoAgregarDto);
            if (respuesta == null)
            {
                return null;
            }
            return "Se encontro un problema al registrar el pedido";


        }

        private string GuardarPedidoEnBaseDatos(List<PedidoAgregarDTO> pedidoAgregarDto)
        {

            PedidoOrdenModelo pedidoAGuardar = new PedidoOrdenModelo();

            pedidoAGuardar.ClienteId = pedidoAgregarDto[Helper.IndiceSiExisteClienteParaAgregarPedido].Id;
            pedidoAGuardar.VendedorId = pedidoAgregarDto[Helper.IndiceSiExisteVendedorParaAgregarPedido].Id;
            _context.Pedido.Add(pedidoAGuardar);
            _context.SaveChanges();
            for (int a = Helper.IndiceParaEmpezarAIterarSobreProductos; a < pedidoAgregarDto.Count; a++)
            {
                try
                {
                    PedidoItemModelo pedidoItem = new PedidoItemModelo();
                    var producto = _context.Producto.Find(pedidoAgregarDto[a].Id);
                    pedidoItem.Precio = producto.price;
                    pedidoItem.ProductoId = producto.id;
                    pedidoItem.ProductoNombre = producto.Nombre;
                    pedidoItem.Cantidad = pedidoAgregarDto[a].quantity;
                    pedidoItem.PedidoId = pedidoAGuardar.PedidoId;
                    _context.PedidoItem.Add(pedidoItem);
                }
                catch (Exception e)
                {
                    return "Error al guardar los datos"+ e.Message;

                }



            }
            int respuestaAlGuradarenBD = _context.SaveChanges();
            if(respuestaAlGuradarenBD>0)
            {
                return null;
            }

            return "Error al guardar los datos ";
        }
    }
}
