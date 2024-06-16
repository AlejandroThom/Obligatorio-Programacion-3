using DTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.MovimientoStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class MovimientoMappers
    {
        public static MovimientoDTO ToDto(MovimientosStock mov)
        {
            if (mov == null) throw new MovimientoStockException("Error en los datos");
            return new MovimientoDTO()
            {
                Id = mov.Id,
                HoraMovimiento = mov.HoraMovimiento,
                FechaMovimiento = mov.FechaMovimiento,
                CantidadEnMovimiento = mov.CantidadEnMovimiento,
                TipoDeMovimiento = TipoMovimientoMappers.ToDto(mov.TipoDeMovimiento),
                ArticuloMovimiento  = ArticuloMappers.ToDto(mov.ArticuloMovimiento),
                UsuarioEncargado = UsuarioMappers.ToUsuarioListadoDTO(mov.UsuarioEncargado),
            };
        }

        public static IEnumerable<MovimientoDTO> ToListadoDTOs(IEnumerable<MovimientosStock> movimientos)
        {
            return movimientos.Select(ToDto);
        }
    }
}
