using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioMovimiento : IRepositorio<MovimientosStock>
    {
        public IEnumerable<object> ResumenDeMovimientosPorAnio();
        public int CantidadDeMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento);
        public IEnumerable<MovimientosStock> ObtenerMovimientosDadoArticuloYTipoMovimiento(int idArticulo,int idTipoMovimiento,int pagina);
    }
}
