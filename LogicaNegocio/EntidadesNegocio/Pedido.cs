using LogicaNegocio.Enums;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Pedido:IValidable
    {
        public int Id { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<Linea> Lineas { get; set; }

        public Pedido(){}

        /// <summary>
        /// Varifica que el pedido sea valido
        /// </summary>
        public void Validar()
        {
            ValidarCliente();
            ValidarFechaEntrega();
        }
        /// <summary>
        /// Valida que el usuario sea uno real.
        /// </summary>
        /// <exception cref="PedidoException"></exception>
        private void ValidarCliente()
        {
            if (Cliente is null)
                throw new PedidoException("El cliente debe existe para realizar el pedido.");
        }

        public void ValidarFechaEntrega()
        {
            if(TipoPedido == TipoPedido.PEDIDOEXPRESS && (FechaEntrega - FechaPedido).TotalDays > 5)
            {
                throw new PedidoException("El pedido express no puede superar los 5 días de diferencia");
            }
            if ((FechaEntrega - FechaPedido).TotalDays<0)
            {
                throw new PedidoException("Los pedidos no pueden entregar en el pasado");
            }
            if (TipoPedido == TipoPedido.PEDIDOCOMUN && (FechaEntrega - FechaPedido).TotalDays <= 7)
            {
                throw new PedidoException("Los pedidos común no pueden tener una fecha prometida menor a una semana");
            }
        }

        private decimal PrecioTotalLineas()
        {
            decimal total = 0;
            foreach(Linea linea in Lineas)
            {
                total += linea.PrecioTotal();
            }
            return total;
        }

        public decimal PrecioFinal(double iva)
        {
            decimal precioTotal = PrecioTotalLineas();
            if(TipoPedido == TipoPedido.PEDIDOEXPRESS)
            {
                if ((FechaEntrega - FechaPedido).TotalDays > 0)
                    precioTotal *= (decimal)0.1;
                else
                    precioTotal *= (decimal)0.15;
            }
            if (TipoPedido == TipoPedido.PEDIDOCOMUN && Cliente.DistanciaPapeleria > 100)
                precioTotal *= (decimal)0.05;

            return precioTotal * ((decimal)iva/100);
        }

    }
}
