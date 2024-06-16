
using LogicaNegocio.Excepciones.TipoMovimiento;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(NombreMovimiento),IsUnique =true)]
    public class TipoMovimiento
    {
        public int Id { get; set; }
        [Required]
        public string NombreMovimiento { get; set; }

        [AllowedValues(['-','+','=','*'])]
        public char Tipo {  get; set; }

        public virtual IEnumerable<MovimientosStock> Movimientos { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NombreMovimiento)) throw new TipoMovimientoException("El nombre debe ser uno valido");
            if (NombreMovimiento.Length <3) throw new TipoMovimientoException("El nombre no es valido");

        }
    }
}