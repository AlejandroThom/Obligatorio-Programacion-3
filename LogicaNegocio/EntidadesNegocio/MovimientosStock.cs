using LogicaNegocio.Excepciones.MovimientoStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class MovimientosStock
    {
        public int Id { get; set; }
        public DateOnly FechaMovimiento { get; set; }
        public TimeOnly HoraMovimiento { get; set; }
        public Articulo ArticuloMovimiento { get; set; }
        public int ArticuloMovimientoId { get; set; }
        public TipoMovimiento TipoDeMovimiento { get; set; }
        public int TipoDeMovimientoId { get; set; }
        public Usuario UsuarioEncargado { get; set; }
        public int UsuarioEncargadoId { get; set; }
        public int CantidadEnMovimiento { get; set; }


        public void Validar()
        {
            ValidarCantidadEnMovimiento();
        }

        public void ValidarCantidadEnMovimiento()
        {
            if (CantidadEnMovimiento <= 0) throw new MovimientoStockException("La cantidad de un articulo debe ser mayor a 0");
        }

    }
}
