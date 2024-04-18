using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {
        bool NombreArticuloExiste(string nombreArticulo);

        IEnumerable<Articulo> ObtenerArticulosOrdenados();
    }
}
