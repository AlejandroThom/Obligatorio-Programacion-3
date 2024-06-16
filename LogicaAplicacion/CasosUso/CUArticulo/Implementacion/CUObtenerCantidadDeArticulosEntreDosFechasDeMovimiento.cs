using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento : ICUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento
    {
        public IRepositorioArticulo Repo { get; set; }
        public CUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public int ObtenerCantidadArticulosPorMovimientosDeStockEntreDosFechas(DateTime inicio, DateTime fin)
        {
            return Repo.ObtenerCantidadArticulosPorMovimientosDeStockEntreDosFechas(inicio, fin);
        }
    }
}
