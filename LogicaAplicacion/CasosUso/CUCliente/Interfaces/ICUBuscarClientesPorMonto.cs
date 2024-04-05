using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Interfaces
{
    public interface ICUBuscarClientesPorMonto
    {
        IEnumerable<Cliente> FindClientePorMonto(decimal monto);
    }
}
