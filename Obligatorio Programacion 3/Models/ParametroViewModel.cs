using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Obligatorio_Programacion_3.Models
{
    public class ParametroViewModel
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        [Required]
        [NotNull]
        public decimal Valor { get; set; }

    }
}
