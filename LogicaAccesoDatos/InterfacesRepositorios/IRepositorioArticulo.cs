using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {
        bool NombreArticuloExiste(string nombreArticulo);
        bool ArticuloExiste(int id);
        public int ObtenerCantidadArticulosPorMovimientosDeStockEntreDosFechas(DateTime inicio, DateTime fin);
        IEnumerable<Articulo> ObtenerArticulosPorMovimientosDeStockEntreDosFechas(DateTime inicio, DateTime fin,int pagina);
        IEnumerable<Articulo> ObtenerArticulosOrdenados();
    }
}
