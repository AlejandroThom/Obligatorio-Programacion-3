using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Params
{
    public class ParametroException : Exception
    {
        public ParametroException() :base() { }
        public ParametroException(string message) : base(message) { }

        public ParametroException(string message,Exception ex) : base(message,ex) { }
    }
}
