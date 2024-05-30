using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Mapper;
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

        public TipoMovimientoDTO ObtenerTipoMovimientoPorId(int id)
        {
            return TipoMovimientoMappers.ToDto( Repo.FindById(id));
        }
    }
}
