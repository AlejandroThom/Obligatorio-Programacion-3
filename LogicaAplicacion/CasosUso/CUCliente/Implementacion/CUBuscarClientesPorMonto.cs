using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Implementacion
{
    public class CUBuscarClientesPorMonto : ICUBuscarClientesPorMonto
    {
        public IRepositorioCliente<Cliente> Repositorio {  get; set; }

        public CUBuscarClientesPorMonto(IRepositorioCliente<Cliente> repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<Cliente> FindClientePorMonto(decimal monto)
        {
            return Repositorio.FindClientsByAmountSpent(monto);
        }
    }
}
