using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces
{
    public interface ICUObtenerMovimientosDadoArticuloYTipoMovimiento
    {
        IEnumerable<MovimientoDTO> ObtenerMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento, int pagina);
    }
}
