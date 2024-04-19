
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUObtenerPedidosAnulados : ICUObtenerPedidosAnulados
    {
        public IRepositorioPedido Repositorio { get; set; }

        public CUObtenerPedidosAnulados(IRepositorioPedido repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<Pedido> ObtenerPedidosAnulados()
        {
            return Repositorio.FindPedidosAnulados();
        }
    }
}
