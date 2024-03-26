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
    public class CUAltaArticulo:ICUAltaArticulo
    {
        public IRepositorio<Articulo> RepoArticulos{ get; set; }

        public CUAltaArticulo(IRepositorio<Articulo> repoArticulos)
        {
            RepoArticulos = repoArticulos;
        }

        public void AltaArticulo(Articulo articulo)
        {
            RepoArticulos.Add(articulo);
        }
    }
}
