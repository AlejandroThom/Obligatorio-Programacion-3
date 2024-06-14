using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.MovimientoStock
{
    public class MovimientoStockException : Exception
    {
        public MovimientoStockException() : base() { }
        public MovimientoStockException(string message) : base(message) { }
        public MovimientoStockException(string message,Exception innerException) : base(message,innerException) { }

    }
}
