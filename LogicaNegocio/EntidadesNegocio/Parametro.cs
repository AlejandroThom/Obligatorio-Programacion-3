using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    [Table("Parametros")]
    [Index(nameof(Nombre),IsUnique =true)]
    public class Parametro
    {
        public int Id {  get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="El nombre no puede ser vacío")]
        public string Nombre { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
