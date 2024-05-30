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
    public class CUActualizarTipoMovimiento : ICUActualizarTipoMovimiento
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUActualizarTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }

        public void ActualizarTipoMovimiento(TipoMovimientoDTO item)
        {
            Repo.Update(TipoMovimientoMappers.ToTipoMovimiento(item));
        }
    }
}
