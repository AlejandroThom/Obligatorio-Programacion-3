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

    }
}
