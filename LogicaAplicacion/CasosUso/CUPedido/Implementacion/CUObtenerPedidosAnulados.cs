
using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUObtenerPedidosAnulados : ICUObtenerPedidosAnulados
    {
        public IRepositorioPedido Repositorio { get; set; }

        public CUObtenerPedidosAnulados(IRepositorioPedido repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<PedidoListadoDTO> ObtenerPedidosAnulados()
        {
            return Mapper.PedidoMappers.ToListaDto(Repositorio.FindPedidosAnulados());
        }
    }
}
