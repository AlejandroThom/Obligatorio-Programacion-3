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
    public class CUObtenerUsuarios : ICUObtenerUsuarios
    {
        public IRepositorio<Usuario> Repositorio { get; set; }

        public CUObtenerUsuarios(IRepositorio<Usuario> repositorio)
        {
            Repositorio = repositorio;
        }

        /// <summary>
        /// Recuperas una lista con todos los usuarios guardados.
        /// </summary>
        /// <returns>Retorna una lista con todos los usarios</returns>
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return Repositorio.FindAll();
        }
    }
}
