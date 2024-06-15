using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {
        public PapeleriaContext Context { get; set; }
        public RepositorioRol(PapeleriaContext context)
        {
            Context = context;
        }

        public Rol BuscarRolPorNombre(string Nombre)
        {
            return Context.Roles.SingleOrDefault(r => r.Nombre.Equals(Nombre)) ?? throw new RolException("El rol no existe");
        }
    }
}
