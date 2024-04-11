using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUEliminarArticulo : ICUEliminarArticulo
    {
        public IRepositorioArticulo RepoArticulos { get; set; }

        public CUEliminarArticulo(IRepositorioArticulo repoArticulos)
        {
            RepoArticulos = repoArticulos;
        }
        public void EliminarArticulo(int id)
        {
            RepoArticulos.Delete(id);
        }
    }
}
