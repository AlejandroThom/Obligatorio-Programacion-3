using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class ParamException : Exception
    {
        public ParamException() : base() { }
        public ParamException(string message) : base(message) { }

        public ParamException(string message, Exception ex) : base(message, ex) { }
    }
}
