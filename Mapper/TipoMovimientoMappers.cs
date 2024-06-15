using DTO;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class TipoMovimientoMappers
    {
        public static TipoMovimientoDTO ToDto(TipoMovimiento item)
        {
            if (item == null)
                throw new Exception("El objeto no puede ser nulo");
            return new TipoMovimientoDTO
            {
                Id = item.Id,
                NombreMovimiento = item.NombreMovimiento,
                TipoDeMovimiento = item.Tipo,
            };
        }

        public static IEnumerable<TipoMovimientoDTO> ToListadoDto(IEnumerable<TipoMovimiento> items)
        {
            if (items == null)
                throw new Exception("El objeto no puede ser nulo");
            return items.Select(ToDto);
        }

        public static TipoMovimiento ToTipoMovimiento(TipoMovimientoDTO item)
        {
            if (item == null)
                throw new Exception("El objeto no puede ser nulo");
            return new TipoMovimiento
            {
                NombreMovimiento = item.NombreMovimiento,
                Tipo = item.TipoDeMovimiento
            };
        }

        public static IEnumerable<TipoMovimiento> ToListadoTipoMovimiento(IEnumerable<TipoMovimientoDTO> items)
        {
            if (items == null)
                throw new Exception("El objeto no puede ser nulo");
            return items.Select(ToTipoMovimiento);
        }

    }
}
