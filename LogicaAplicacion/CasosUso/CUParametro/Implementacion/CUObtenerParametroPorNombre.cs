using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUParametro.Implementacion
{
    public class CUObtenerParametroPorNombre : ICUObtenerParametroPorNombre
    {
        public IRepositorioParametro Repo { get; set; }

        public CUObtenerParametroPorNombre(IRepositorioParametro repo)
        {
            Repo = repo;
        }
        public decimal ObtenerParametroPorNombre(string nombre)
        {
            return Repo.GetParametroPorNombre(nombre);
        }
    }
}
