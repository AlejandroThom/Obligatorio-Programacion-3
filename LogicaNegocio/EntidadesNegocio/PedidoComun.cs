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

        public override decimal PrecioFinal(decimal iva)
        {
            decimal precioTotal = base.PrecioFinal(iva);
            if ( Cliente.DistanciaPapeleria > 100)
                precioTotal += precioTotal*(decimal)0.05;

            return precioTotal + (precioTotal*(iva/100));
        }
    }
}
