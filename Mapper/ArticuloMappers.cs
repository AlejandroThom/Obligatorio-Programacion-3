using DTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Articulo;

namespace Mapper
{
    public class ArticuloMappers
    {
        public static ArticuloListadoDTO ToDto(Articulo articulo)
        {
            if (articulo == null)
                throw new ArticuloException("Hubo un error");
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
                throw new ArticuloException("Hubo un error");
            return articulos.Select(ToDto);
        }

        public static IEnumerable<ArticuloSelectDTO> ToArticuloSelectDTO(IEnumerable<Articulo> articulos)
        {
            return articulos.Select(a => a == null ? throw new ArticuloException("Hubo un error") : new ArticuloSelectDTO() { Id = a.Id, Nombre = a.NombreArticulo.Nombre });
        }

    }


}
