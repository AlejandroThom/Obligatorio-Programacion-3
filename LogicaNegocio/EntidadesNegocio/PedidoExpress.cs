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
        public override decimal PrecioFinal(decimal iva)
        {
            decimal precioTotal = base.PrecioFinal(iva);
            if ((FechaEntrega - FechaPedido).TotalDays > 0)
                precioTotal += precioTotal * (decimal)0.1;
            else
                precioTotal += precioTotal * (decimal)0.15;
            return precioTotal + (precioTotal * (iva / 100));
        }
    }
}
