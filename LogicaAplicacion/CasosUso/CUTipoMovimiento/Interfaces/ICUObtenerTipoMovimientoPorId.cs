using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces
{
    public interface ICUObtenerTipoMovimientoPorId
    {
        TipoMovimiento ObtenerTipoMovimientoPorId(int id);
    }
}
