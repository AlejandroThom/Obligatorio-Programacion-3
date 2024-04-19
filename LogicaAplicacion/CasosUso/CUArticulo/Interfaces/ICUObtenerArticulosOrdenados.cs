using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUArticulo.Interfaces
{
    public interface ICUObtenerArticulosOrdenados
    {
        IEnumerable<Articulo> ObtenerArticulosOrdenados();
    }
}
