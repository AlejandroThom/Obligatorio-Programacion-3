using LogicaAccesoDatos.BaseDatos;
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
    public class CUAltaUsuario : ICUAltaUsuario
    {
        public IRepositorioUsuario Repositorio { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }

        public void AltaUsuario(Usuario usuario)
        {
            Repositorio.Add(usuario);
        }
    }
}
