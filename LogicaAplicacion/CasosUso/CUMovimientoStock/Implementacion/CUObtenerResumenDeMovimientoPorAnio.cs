using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUMovimientoStock.Implementacion
{
    public class CUObtenerResumenDeMovimientoPorAnio : ICUObtenerResumenDeMovimientoPorAnio
    {
        public IRepositorioMovimiento Repo { get; set; }
        public CUObtenerResumenDeMovimientoPorAnio(IRepositorioMovimiento repo)
        {
            Repo = repo;
        }

        public IEnumerable<object> ObtenerResumenDeMovimientoPorAnio()
        {
            return Repo.ResumenDeMovimientosPorAnio();
        }
    }
}
