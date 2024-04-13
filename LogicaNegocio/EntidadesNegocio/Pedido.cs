using LogicaNegocio.Enums;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Pedido:IValidable
    {
        public int Id { get; set; }
        [AllowedValues([1,2],ErrorMessage ="El pedido solo puede ser Express o común")]
        public Cliente Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        [DefaultValue(false)]
        public bool IsAnulado { get; set; }
        public List<Linea> Lineas { get; set; } 
        public decimal PrecioPedidoFinal {  get; set; }

        public Pedido(){
            Lineas = new List<Linea>();
        }

        public bool IsEntregado()
        {
            return FechaEntrega < DateTime.Today && IsAnulado == false;
        }


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

        public virtual void ValidarFechaEntrega()
        {
            if ((FechaEntrega - FechaPedido).TotalDays<0)
            {
                throw new PedidoException("Los pedidos no pueden entregar en el pasado");
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

        public virtual decimal PrecioFinal(decimal iva)
        {
            decimal precioTotal = PrecioTotalLineas();
            return precioTotal;
        }

        private void IsPedidoAnulado() {
            if (IsAnulado)
                throw new PedidoException("El pedido está anulado, no puede agregarle nuevas lineas");
        }

        private void IsPedidoEntregado()
        {
            if (IsEntregado())
                throw new PedidoException("El pedido ya ha sido entregado, no puede agregarle nuevas lineas");
        }

        public void IsPedidoModificable()
        {
            IsPedidoAnulado();
            IsPedidoEntregado();
        }

        public void IsLineaExistente(Linea item)
        {
            if (Lineas.Contains(item))
                throw new PedidoException("El articulo que intenta agregar ya esta agregado.");
        }
    }
}
