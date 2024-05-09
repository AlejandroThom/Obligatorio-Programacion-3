using DTO;

namespace LogicaAplicacion.CasosUso.CUPedido.Interfaces
{
    public interface ICUObtenerPedidosAnulados
    {
        IEnumerable<PedidoListadoDTO> ObtenerPedidosAnulados();
    }
}
