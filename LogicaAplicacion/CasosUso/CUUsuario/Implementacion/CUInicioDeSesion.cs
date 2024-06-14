using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario.Implementacion
{
    public class CUInicioDeSesion : ICUInicioDeSesion
    {
        public IRepositorioUsuario Repositorio {  get; set; }

        public CUInicioDeSesion(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }

        public UsuarioLoginRetornoDTO BuscarUsuarioPorEmailYPassword(String email, String pass)
        {
            return UsuarioMappers.ToRetornoLoginUsuarioDTO(Repositorio.FindByEmailAndPass(email, pass));
        }
    }
}
