using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    internal class PedidoException:Exception
    {
        public PedidoException() { }

        public PedidoException(string message) : base(message) { }

        public PedidoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
