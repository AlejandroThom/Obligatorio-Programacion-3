using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects.UsuarioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario.Implementacion
{
    public class CUBuscarUsuario : ICUBuscarUsuario
    {
        public IRepositorioUsuario Repositorio { get; set; }

        public CUBuscarUsuario(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return Repositorio.FindById(id);
        }

        public Usuario BuscarUsuarioPorEmailYPassword(String email,String pass) // incorporar en un nuevo caso de uso
        {
            return Repositorio.FindByEmailAndPass(email, pass);
        }
    }
}
