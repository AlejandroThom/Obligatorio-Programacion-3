using DTO;
using LogicaNegocio.EntidadesNegocio;
using Mapper.InterfacesMapper;

namespace Mapper
{
    public class PedidoMappers : IMapper<PedidoListadoDTO, Pedido>
    {
        /*
        public static Pedido FromDto(PedidoListadoDTO dto)
        {
            if (dto == null)
                throw new Exception("El objeto no puede ser nulo");
            Pedido dev;
            if (dto.IsExpress)
                dev = new PedidoExpress();
            else
                dev = new PedidoComun();
            dev.Id = dto.Id;
            dev.FechaEntrega = dto.FechaEntrega;
            dev.PrecioPedidoFinal = dto.PrecioTotal;
            dev.Cliente = new Cliente() { RazonSocial = dto.Cliente, Id = dto.IdCliente };
            return dev;
        }*/

        public static PedidoListadoDTO ToDto(Pedido pedido)
        {
            if (pedido == null)
                throw new Exception("El objeto no puede ser nulo");
            return new PedidoListadoDTO
            {
                FechaEntrega = pedido.FechaEntrega,
                Id = pedido.Id,
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
