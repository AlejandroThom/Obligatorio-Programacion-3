using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TipoMovimientoDTO
    {
        public int Id { get; set; }
        [StringLength(80,MinimumLength =4,ErrorMessage ="El nombre del tipo de movimiento debe tener al menos 4 caracteres.")]
        public String NombreMovimiento { get; set; }
    }
}
