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
    public class CUModificarCiente : ICUModificarCliente
    {
        public IRepositorio<Cliente> RepoClientes { get; set; }

        public CUModificarCliente(IRepositorio<Cliente> repoClientes)
        {
            RepoClientes = repoClientes;
        }
        public void ModificarCliente(Cliente cliente)
        {
            RepoClientes.Update(editorial);
        }
    }
}
