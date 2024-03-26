using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Interfaces
{
    public interface ICUObtenerArticulos
    {
        IEnumerable<Articulo> ObtenerArticulos();
        Task<IEnumerable<Articulo>> ObtenerArticulosAsync();

    }
}
