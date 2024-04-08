using LogicaNegocio.ValueObjects.ArticulosVO;

namespace Obligatorio_Programacion_3.Models
{
    public class ArticuloListadoViewModel : IComparable<ArticuloListadoViewModel>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioPublico { get; set; }
        public string CodigoArticulo { get; set; }
        public int Stock { get; set; }


        public int CompareTo(ArticuloListadoViewModel? other)
        {
            return other.Nombre.CompareTo(Nombre);
        }
    }
}
