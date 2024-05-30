using DTO;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces
{
    public interface ICUActualizarTipoMovimiento
    {
        void ActualizarTipoMovimiento(TipoMovimientoDTO item);
    }
}
