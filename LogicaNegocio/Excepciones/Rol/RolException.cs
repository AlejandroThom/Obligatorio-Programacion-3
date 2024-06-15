using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Rol
{
    public class RolException :Exception
    {
        public RolException() :base() { }
        public RolException(string message) : base(message) { }
        public RolException(string message,Exception innerException) : base(message, innerException) { }
    }
}
