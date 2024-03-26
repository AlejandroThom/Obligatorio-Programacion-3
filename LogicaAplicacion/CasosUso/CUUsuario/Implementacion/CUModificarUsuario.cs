using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario.Implementacion
{
    public class CUModificarUsuario : ICUModificarUsuario
    {
        public IRepositorio<Usuario> Repositorio { get; set; }

        public CUModificarUsuario(IRepositorio<Usuario> repo) => Repositorio = repo;

        public void ModificarUsuario(Usuario usuario)
        {
            Repositorio.Update(usuario);
        }
    }
}
