using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Interfaces
{
    public interface ICUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento
    {
        int ObtenerCantidadArticulosPorMovimientosDeStockEntreDosFechas(DateTime inicio, DateTime fin);
    }
}
