using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUObtenerArticulosParaSeleccion : ICUObtenerArticulosParaSeleccion
    {
        public IRepositorioArticulo RepoArticulos { get; set; }

        public CUObtenerArticulosParaSeleccion(IRepositorioArticulo repoArticulos)
        {
            RepoArticulos = repoArticulos;
        }

        public IEnumerable<ArticuloSelectDTO> ObtenerArticulosParaSeleccion()
        {
            return ArticuloMappers.ToArticuloSelectDTO(RepoArticulos.FindAll());
        }
    }
}
