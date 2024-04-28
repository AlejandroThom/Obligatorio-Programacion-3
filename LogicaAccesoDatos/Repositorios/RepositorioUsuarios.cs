using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuario
    {
        private readonly PapeleriaContext _context;
        public RepositorioUsuarios(PapeleriaContext context)
        {
            _context = context;
        }
        public void Add(Usuario item)
        {
            item.Validar();
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario user = FindById(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No existe un usuario con ese id");
            }

        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Update(Usuario item)
        {
            Usuario user = FindById(item.Id);
            if (user != null)
            {
                user.NombreUsuario = item.NombreUsuario;
                user.ApellidoUsuario = item.ApellidoUsuario;
                user.PasswordUsuario = item.PasswordUsuario;
                user.PasswordEncriptada = item.PasswordEncriptada;
                _context.Usuarios.Update(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No existe un usuario con ese id");
            }
        }
        public Usuario FindByEmailAndPass(String email, String pass)
        {
            return _context.Usuarios.SingleOrDefault(u => u.EmailUsuario.Email == email && u.PasswordEncriptada == pass);
        }

        public bool UsuarioExiste(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.EmailUsuario.Email.Equals(usuario.EmailUsuario.Email)) != null;
        }
    }
}
