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
    public class CUBuscarClientePorId : ICUBuscarClientePorId
    {
        public IRepositorioCliente Repo { get; set; }
        public CUBuscarClientePorId(IRepositorioCliente repo)
        {
            this.Repo = repo;
        }
        public Cliente BuscarClientePorId(int id)
        {
            return Repo.FindById(id);
        }
    }
}
