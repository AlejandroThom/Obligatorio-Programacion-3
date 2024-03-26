﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class ArticuloException : Exception
    {
        public ArticuloException() { }

        public ArticuloException(string message) : base(message) { }

        public ArticuloException(string message, Exception innerException) : base(message, innerException) { }

    }
}
