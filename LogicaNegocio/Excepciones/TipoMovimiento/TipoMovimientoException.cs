using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoMovimiento
{
    public class TipoMovimientoException : Exception
    {
        public TipoMovimientoException() { }
        public TipoMovimientoException(string message) : base(message) { }
        public TipoMovimientoException(string message,Exception exception) : base(message, exception) { }
    }
}
