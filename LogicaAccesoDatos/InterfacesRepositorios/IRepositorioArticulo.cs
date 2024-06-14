using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {
        bool NombreArticuloExiste(string nombreArticulo);
        bool ArticuloExiste(int id);

        IEnumerable<Articulo> ObtenerArticulosOrdenados();
    }
}
