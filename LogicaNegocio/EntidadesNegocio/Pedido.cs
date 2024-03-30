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
    }
}
