using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Implementacion
{
    public class CUEliminarCliente : ICUEliminarCliente
    {
        public IRepositorio<Cliente> RepoClientes { get; set; }

        public CUEliminarCliente(IRepositorio<Cliente> repoClientes)
        {
            RepoClientes = repoClientes;
        }
        public void EliminarCliente(int id)
        {
            RepoClientes.Delete(id);
        }
    }
}
