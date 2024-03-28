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
    public class CUObtenerClientes : ICUObtenerClientes
    {
        public IRepositorio<Cliente> RepoClientes { get; set; }

        public CUObtenerClientes(IRepositorio<Cliente> repoClientes)
        {
            RepoClientes = repoClientes;
        }
        public IEnumerable<Cliente> ObtenerClientes()
        {
            return RepoClientes.FindAll();
        }

        public async Task<IEnumerable<Cliente>> ObtenerClientesAsync()
        {
            return await RepoClientes.FindAllAsync();
        }
    }
}

