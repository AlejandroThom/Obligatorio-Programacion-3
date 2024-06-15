using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Mapper;

namespace LogicaAplicacion.CasosUso.CUParametro.Implementacion
{
    public class CUObtenerParametroPorNombre : ICUObtenerParametroPorNombre
    {
        public IRepositorioParametro Repo { get; set; }

        public CUObtenerParametroPorNombre(IRepositorioParametro repo)
        {
            Repo = repo;
        }
        public ParametroDTO ObtenerParametroPorNombre(string nombre)
        {
            return ParametroMappers.ToDTO(Repo.GetParametroPorNombre(nombre));
        }
    }
}
