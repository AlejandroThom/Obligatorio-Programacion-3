using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUParametro.Implementacion
{
    public class CUObtenerParametroPorNombre : ICUObtenerParametroPorNombre
    {
        public IRepositorioParametro Repo { get; set; }

        public CUObtenerParametroPorNombre(IRepositorioParametro repo)
        {
            Repo = repo;
        }
        public Parametro ObtenerParametroPorNombre(string nombre)
        {
            return Repo.GetParametroPorNombre(nombre);
        }
    }
}
