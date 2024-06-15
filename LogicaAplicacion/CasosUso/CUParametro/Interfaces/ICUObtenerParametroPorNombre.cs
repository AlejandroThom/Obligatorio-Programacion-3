using DTO;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUParametro.Interfaces
{
    public interface ICUObtenerParametroPorNombre
    { 
        ParametroDTO ObtenerParametroPorNombre(string nombre);
    }
}
