using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Linea
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int CantArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Linea() { }

        public decimal PrecioTotal()
        {
            return CantArticulo*PrecioUnitario;
        }
    }
}