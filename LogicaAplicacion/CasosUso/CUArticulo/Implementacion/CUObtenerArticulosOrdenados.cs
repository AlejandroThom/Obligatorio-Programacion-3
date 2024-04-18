using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using Mapper;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUObtenerArticulosOrdenados : ICUObtenerArticulosOrdenados
    {
        public IRepositorioArticulo Repo { get; set; }
        public CUObtenerArticulosOrdenados(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public IEnumerable<ArticuloListadoDTO> ObtenerArticulosOrdenados()
        {
            return ArticuloMappers.ToListaDto(Repo.ObtenerArticulosOrdenados());
        }
    }
}
