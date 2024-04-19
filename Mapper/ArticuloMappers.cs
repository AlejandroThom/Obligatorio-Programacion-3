using DTO;
using LogicaNegocio.EntidadesNegocio;

namespace Mapper
{
    public static class ArticuloMappers
    {
        public static ArticuloListadoDTO ToDto(Articulo articulo)
        {
            if (articulo == null)
                throw new ArgumentNullException();
            return new ArticuloListadoDTO()
            {
                Id = articulo.Id,
                CodigoArticulo = articulo.CodigoArticulo.Codigo,
                DescripcionArticulo = articulo.DescripcionArticulo.Descripcion,
                NombreArticulo = articulo.NombreArticulo.Nombre,
                Stock = articulo.Stock,
                PrecioPublico = articulo.PrecioPublico
            };
        }
        public static IEnumerable<ArticuloListadoDTO> ToListaDto(IEnumerable<Articulo> articulos)
        {
            if (articulos == null)
                throw new ArgumentNullException();
            return articulos.Select(ar => ToDto(ar));
        }

    }


}
