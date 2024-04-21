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
    public class CUEliminarUsuario : ICUEliminarUsuario
    {
        public IRepositorioUsuario Repositorio { get; set; }

        public CUEliminarUsuario(IRepositorioUsuario repositorio)
        {
            Repositorio = repositorio;
        }
        public void EliminarUsuario(int id)
        {
            Repositorio.Delete(id);
        }
    }
}
