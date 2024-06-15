using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario.Implementacion
{
    public class CUBuscarUsuarioPorEmail : ICUBuscarUsuarioPorEmail
    {
        public IRepositorioUsuario Repositorio { get; set; }

        public CUBuscarUsuarioPorEmail(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }
        public UsuarioDTO BuscarUsuarioPorEmail(string email)
        {
            return UsuarioMappers.ToUsuarioDTO(Repositorio.FindByEmail(email));
        }
    }
}
