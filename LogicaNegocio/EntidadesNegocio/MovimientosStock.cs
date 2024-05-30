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
        public TipoMovimiento TipoDeMovimiento { get; set; }
        public Usuario UsuarioEncargado { get; set; }
        public int CantidadEnMovimiento { get; set; }

    }
}
