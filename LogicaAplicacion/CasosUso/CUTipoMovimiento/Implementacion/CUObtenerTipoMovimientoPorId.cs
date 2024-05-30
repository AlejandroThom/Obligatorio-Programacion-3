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
    public class CUObtenerTipoMovimientoPorId :ICUObtenerTipoMovimientoPorId
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUObtenerTipoMovimientoPorId(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }

        public TipoMovimiento ObtenerTipoMovimientoPorId(int id)
        {
            return Repo.FindById(id);
        }
    }
}
