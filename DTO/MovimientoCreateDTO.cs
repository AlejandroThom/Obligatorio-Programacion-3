using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MovimientoCreateDTO
    {
        public int IdArticulo {  get; set; }
        public DateTime FechaRealizacion { get; set; }
        public int CantidadArticulo { get; set; }
        public int TipoMovimientoId { get; set; }
        public string EmailUsuario {  get; set; }
    }
}
