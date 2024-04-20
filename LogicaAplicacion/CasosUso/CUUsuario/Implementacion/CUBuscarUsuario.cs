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
        public IRepositorio<Usuario> Repositorio { get; set; }

        public CUBuscarUsuario(IRepositorio<Usuario> repositorio)
        {
            Repositorio = repositorio;
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return Repositorio.FindById(id);
        }

        public Usuario BuscarUsuarioPorEmailYPassword(EmailVO email,PasswordVO pass) 
        {
            return Repositorio.FindByEmailAndPass(email, pass);
        }
    }
}
