using LogicaNegocio.ValueObjects.ArticulosVO;

namespace DTO
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string NombreArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public decimal PrecioPublico { get; set; }
        public string CodigoArticulo { get; set; }
        public int Stock { get; set; }
    }
}
