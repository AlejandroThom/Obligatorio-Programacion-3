using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUPedido.Interfaces
{
    public interface ICUObtenerPedidosAnulados
    {
        IEnumerable<Pedido> ObtenerPedidosAnulados();
    }
}
