using DTO;
using LogicaNegocio.EntidadesNegocio;

namespace Mapper
{
    public class PedidoMappers
    {
        public static Pedido FromDto(PedidoListadoDTO dto)
        {
            //TODO:Falta mappear de ClienteDTO A Cliente.
            if (dto == null)
                throw new Exception("El objeto no puede ser nulo");
            Pedido dev;
            if (dto.IsExpress)
                dev = new PedidoExpress() {FechaEntrega=dto.FechaEntrega,PrecioPedidoFinal=dto.PrecioTotal,Id=dto.Id };
            else
                dev = new PedidoComun();
            return dev;
        }

        public static PedidoListadoDTO ToDto(Pedido pedido)
        {
            //TODO:Falta mappear de Cliente A ClienteDTO.
            if (pedido == null)
                throw new Exception("El objeto no puede ser nulo");
            return new PedidoListadoDTO
            {
                FechaEntrega = pedido.FechaEntrega,
                Id = pedido.Id,
                IsExpress = pedido is PedidoExpress,
                PrecioTotal = pedido.PrecioPedidoFinal
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
            return pedis.Select(p => ToDto(p));
        }

    }
}
