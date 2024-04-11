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
    public class CUModificarArticulo : ICUModificarArticulo
    {
        public IRepositorioArticulo RepoArticulos { get; set; }

        public CUModificarArticulo(IRepositorioArticulo repoArticulos)
        {
            RepoArticulos = repoArticulos;
        }
        public void ModificarEditorial(Articulo editorial)
        {
            RepoArticulos.Update(editorial);
        }
    }
}
