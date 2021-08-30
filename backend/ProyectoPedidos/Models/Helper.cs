using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPedidos.Models
{
    public static class Helper
    {
        public static  string EstadoPedidoRegistrado = "REGISTRADO";
        public static string EstadoPedidoAprobado = "APROBADO";
        public static string MensajeDeExito = "EXITO";

        public static int IndiceSiExisteClienteParaAgregarPedido = 0;
        public static int IndiceSiExisteVendedorParaAgregarPedido = 1;
        public static int TamanoDelArrayParaQueSeaValidoParaGuardarUnPedido = 3;
        public static int CantidadNoPuedeSerCero = 0;

        public static int IndiceParaEmpezarAIterarSobreProductos = 2;

    }
}
