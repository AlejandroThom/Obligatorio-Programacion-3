using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUParametro.Interfaces
{
    public interface ICUObtenerParametroPorNombre
    {
        Parametro ObtenerParametroPorNombre(string nombre);
    }
}
