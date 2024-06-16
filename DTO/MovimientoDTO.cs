using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        public DateOnly FechaMovimiento { get; set; }
        public TimeOnly HoraMovimiento { get; set; }
        public ArticuloListadoDTO ArticuloMovimiento { get; set; }
        public TipoMovimientoDTO TipoDeMovimiento { get; set; }
        public UsuarioListadoDTO UsuarioEncargado { get; set; }
        public int CantidadEnMovimiento { get; set; }
    }
}
