using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CURol.Interfaces
{
    public interface ICUBuscarRolPorNombre
    {
        public DTORol BuscarRolPorNombre(string nombre);
    }
}
