using ProyectoPedidos.DataContext;
using ProyectoPedidos.DTOs;
using ProyectoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Domains
{
    public class PedidoDomain
    {
        public string ComprobarParaRegistrarPedido(List<PedidoAgregarDTO> pedidoAgregarDto)
        {

            if (pedidoAgregarDto.Count() < Helper.TamanoDelArrayParaQueSeaValidoParaGuardarUnPedido)
            {
                return "No se han proporcionado todos los datos para poder guardar el pedido";
            }

            for (int i = Helper.TamanoDelArrayParaQueSeaValidoParaGuardarUnPedido; i < pedidoAgregarDto.Count(); i++)
            {
                if (pedidoAgregarDto[i].quantity <= Helper.CantidadNoPuedeSerCero)
                {
                    return "Existen productos con cantiades en 0";
                }
            }


            return null;
        }


        public string ComprobarPedido(PedidoOrdenModelo pedido)
        {
            if (pedido == null)
            {
                return "No se encuentra el Pedido seleccionado";
            }

            if (pedido.Estado != Helper.EstadoPedidoRegistrado)
            {
                return "El pedido se encuentra en un estado que no permite se aprobación";
            }


            return null;
        }


    }
}
