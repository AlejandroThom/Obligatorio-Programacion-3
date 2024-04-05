using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUObtenerPedidosPorFecha : ICUObtenerPedidosPorFecha
    {
        public IRepositorioPedido<Pedido> Repositorio { get; set; }
        public CUObtenerPedidosPorFecha(IRepositorioPedido<Pedido> repo)
        {
            Repositorio = repo;
        }
        public IEnumerable<Pedido> ObtenerPedidosPorFecha(DateTime fecha)
        {
            return Repositorio.FindPedidosByDate(fecha);
        }
    }
}
