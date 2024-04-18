using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using Mapper;

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
            return PedidoMappers.ToListaDto(Repositorio.FindPedidosAnulados());
        }
    }
}
