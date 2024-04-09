using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Obligatorio_Programacion_3.Models
{
    public class ArticuloViewModel
    {
        [MinLength(10, ErrorMessage = "Debe tener como mínimo 10 caracteres")]
        [MaxLength(200, ErrorMessage = "Debe tener como máximo 200 caracteres")]
        public string Nombre { get; set; }
        [MinLength(5, ErrorMessage = "Debe tener al menos 5 caracteres")]
        public string Descripcion { get; set; }
        public decimal PrecioPublico { get; set; }
        [MinLength(13, ErrorMessage = "Debe tener como mínimo 13 caracteres")]
        [MaxLength(13, ErrorMessage = "Debe tener como máximo 13 caracteres")]
        [NotNull]
        public string Codigo { get; set; }
        public int Stock { get; set; }
    }
}
