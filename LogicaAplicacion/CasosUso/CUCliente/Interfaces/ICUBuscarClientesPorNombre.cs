using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Interfaces
{
    public interface ICUBuscarClientesPorNombre
    {
        IEnumerable<Cliente> FindClientesPorNombre(string nombre,string apellido);
    }
}
