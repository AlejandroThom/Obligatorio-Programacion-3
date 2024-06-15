using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CURol.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CURol.Implementacion
{
    public class CUBuscarRolPorNombre : ICUBuscarRolPorNombre
    {
        public IRepositorioRol Repo { get; set; }
        public CUBuscarRolPorNombre(IRepositorioRol repo) {
            Repo = repo;
        }
        public DTORol BuscarRolPorNombre(string nombre)
        {
            Rol rol = Repo.BuscarRolPorNombre(nombre);
            return new DTORol() { Id = rol.Id, Nombre = rol.Nombre };
        }
    }
}
