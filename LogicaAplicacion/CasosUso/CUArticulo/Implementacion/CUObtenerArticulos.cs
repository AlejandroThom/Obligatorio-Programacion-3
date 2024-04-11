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
    public class CUObtenerArticulos : ICUObtenerArticulos
    {
        public IRepositorioArticulo RepoArticulos { get; set; }

        public CUObtenerArticulos(IRepositorioArticulo repoArticulos)
        {
            RepoArticulos = repoArticulos;
        }
        public IEnumerable<Articulo> ObtenerArticulos()
        {
            return RepoArticulos.FindAll();
        }

    }
}
