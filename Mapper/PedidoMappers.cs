using DTO;
using LogicaNegocio.EntidadesNegocio;

namespace Mapper
{
    public class PedidoMappers
    {
        public static PedidoListadoDTO ToDto(Pedido pedido)
        {
            if (pedido == null)
                throw new Exception("El objeto no puede ser nulo");
            return new PedidoListadoDTO
            {
                FechaEntrega = pedido.FechaEntrega,
                IsExpress = pedido is PedidoExpress,
                PrecioTotal = pedido.PrecioPedidoFinal,
                Cliente = pedido.Cliente.RazonSocial,
                IdCliente = pedido.Cliente.Id,
            };
        }
        /// <summary>
        /// Retorna una lista de PedidosListaDTO a partir de una lista de Pedido
        /// </summary>
        /// <param name="pedis">Lista con los pedidos a convertir a DTO</param>
        /// <returns>Retorna una lista de PedidoListaDTO</returns>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<PedidoListadoDTO> ToListaDto(IEnumerable<Pedido> pedis)
        {
            if (pedis == null)
                throw new Exception("El objeto no puede ser nulo");
            return pedis.Select(ToDto);
        }

    }
}
