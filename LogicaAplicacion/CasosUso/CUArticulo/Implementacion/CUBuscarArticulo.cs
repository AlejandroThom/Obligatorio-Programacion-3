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
    public class CUBuscarArticulo:ICUBuscarArticulo
    {
        public IRepositorioArticulo RepoArticulos { get; set; }

        public CUBuscarArticulo(IRepositorioArticulo repoArticulos)
        {
            RepoArticulos = repoArticulos;
        }

        public Articulo BuscarArticuloPorId(int id)
        {
            return RepoArticulos.FindById(id);
        }
    }
}
