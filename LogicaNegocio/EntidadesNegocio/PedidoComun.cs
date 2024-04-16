using LogicaNegocio.Enums;
using LogicaNegocio.Excepciones.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class PedidoComun : Pedido
    {
        public override void ValidarFechaEntrega()
        {
            base.ValidarFechaEntrega();
            if ((FechaEntrega - FechaPedido).TotalDays <= 7)
            {
                throw new PedidoException("Los pedidos común no pueden tener una fecha prometida menor a una semana");
            }
        }

        public override void AsignarPrecioFinal(decimal iva)
        {
            base.AsignarPrecioFinal(iva);
            if ( Cliente.DistanciaPapeleria > 100)
                PrecioPedidoFinal += PrecioPedidoFinal * (decimal)0.05;

            PrecioPedidoFinal += (PrecioPedidoFinal *(iva/100));
        }
    }
}
