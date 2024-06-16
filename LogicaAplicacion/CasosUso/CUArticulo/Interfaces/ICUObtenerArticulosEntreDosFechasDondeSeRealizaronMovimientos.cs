using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Interfaces
{
    public interface ICUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos
    {
        IEnumerable<ArticuloListadoDTO> ObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos(DateTime inicio, DateTime fin, int pagina);
    }
}
