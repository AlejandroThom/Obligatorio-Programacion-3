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
        public IRepositorioCliente Repo { get; set; }

        public CUObtenerClientes(IRepositorioCliente repo)
        {
            this.Repo = repo;
        }

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return Repo.FindAll();
        }
    }
}
