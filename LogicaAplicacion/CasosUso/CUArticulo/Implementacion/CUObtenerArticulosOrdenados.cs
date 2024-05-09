using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;

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
            return Mapper.ArticuloMappers.ToListaDto(Repo.ObtenerArticulosOrdenados());
        }
    }
}
