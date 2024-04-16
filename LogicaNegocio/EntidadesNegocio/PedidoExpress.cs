using LogicaNegocio.Enums;
using LogicaNegocio.Excepciones.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class PedidoExpress : Pedido
    {
        public override void ValidarFechaEntrega()
        {
            base.ValidarFechaEntrega();
            if ((FechaEntrega - FechaPedido).TotalDays > 5)
            {
                throw new PedidoException("El pedido express no puede superar los 5 días de diferencia");
            }
        }
        public override void AsignarPrecioFinal(decimal iva)
        {
            base.AsignarPrecioFinal(iva);
            if (FechaEntrega.Date == FechaPedido.Date)
                PrecioPedidoFinal += PrecioPedidoFinal * (decimal)0.15;
            else
                PrecioPedidoFinal += PrecioPedidoFinal * (decimal)0.10;
            PrecioPedidoFinal += (PrecioPedidoFinal * (iva / 100));
        }
    }
}
