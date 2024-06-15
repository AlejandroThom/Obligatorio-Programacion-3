using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUMovimientoStock.Implementacion
{
    public class CUAltaMovimientoStock : ICUAltaMovimientoStock
    {
        public IRepositorioMovimiento Repositorio {  get; set; }
        public CUAltaMovimientoStock(IRepositorioMovimiento repositorio)
        {
            Repositorio = repositorio;
        }

        public void AltaMovimientoStock(MovimientosStock item)
        {
            Repositorio.Add(item);
        }
    }
}
