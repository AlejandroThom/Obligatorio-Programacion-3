using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUObtenerArticulosOrdenados : ICUObtenerArticulosOrdenados
    {
        public IRepositorioArticulo Repo { get; set; }
        public CUObtenerArticulosOrdenados(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public IEnumerable<Articulo> ObtenerArticulosOrdenados()
        {
            return Repo.ObtenerArticulosOrdenados();
        }
    }
}
