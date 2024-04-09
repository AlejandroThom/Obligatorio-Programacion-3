using LogicaNegocio.EntidadesNegocio;

namespace Obligatorio_Programacion_3.Models
{
    public class LineaViewModel
    {
        public Articulo Articulo { get; set; }
        public int CantArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
