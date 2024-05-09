using DTO;

namespace LogicaAplicacion.CasosUso.CUArticulo.Interfaces
{
    public interface ICUObtenerArticulosOrdenados
    {
        IEnumerable<ArticuloListadoDTO> ObtenerArticulosOrdenados();
    }
}
