using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario FindByEmailAndPass(String email, String pass); //Buscar por email y password

        bool UsuarioExiste(Usuario usuario);
    }
}
