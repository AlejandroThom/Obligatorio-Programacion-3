using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUTipoMovimiento.Implementacion
{
    internal class CUObtenerTiposDeMovimiento : ICUObtenerTiposDeMovimiento
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUObtenerTiposDeMovimiento(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }
        public IEnumerable<TipoMovimiento> ObtenerTIposDeMovimiento()
        {
            return Repo.FindAll();
        }
    }
}
