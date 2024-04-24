
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.Utils;
namespace Testing
{
    public class UsuarioRepositorioTests
    {
        private async Task<PapeleriaContext> GetDBContext()
        {
            var options = new DbContextOptionsBuilder<PapeleriaContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new PapeleriaContext(options);
            databaseContext.Database.EnsureCreated();
            for (int i = 0; i < 4; i++)
            {
                databaseContext.Usuarios.Add(new Usuario(
                    $"ola{i}@gmail.com", $"Luis{i}a", $"Thom{i}a", "abcAb1.", Utilities.Encriptar("abcAb1.")));
            }
            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }



        [Fact]
        public async void UsuarioRepositorio_AddNewUser()
        {
            Usuario user = new Usuario("papu@gmail.com", "Luispep", "Thomu", "abcAb2a1.", Utilities.Encriptar("abcAb1."));
            var dbContext = await GetDBContext();
            var usuarioRepositorio = new RepositorioUsuarios(dbContext);
            usuarioRepositorio.Add(user);
            var search = usuarioRepositorio.FindByEmailAndPass(user.EmailUsuario.Email, user.PasswordEncriptada);
            Assert.IsType<Usuario>(search);
        }

        [Fact]
        public async void UsuarioRepositorio_NotAddNewUser()
        {
            var dbContext = await GetDBContext();
            var usuarioRepositorio = new RepositorioUsuarios(dbContext);

            Usuario user = new Usuario("ola1@gmail.com", $"Luis1a", $"Thom1a", "abcAb1.", Utilities.Encriptar("abcAb1."));
            Assert.True(usuarioRepositorio.UsuarioExiste(user));
            Assert.ThrowsAsync<Exception>(() => Task.Run(() => usuarioRepositorio.Add(user)));
        }

        [Fact]
        public async void UsuarioRepositorio_NotValidUser()
        {

            var dbContext = await GetDBContext();
            var usuarioRepositorio = new RepositorioUsuarios(dbContext);
            Assert.Throws<UsuarioException>(() => new Usuario("@gmail.com", "Luispep", "Thomu", "abcAb2a1.", Utilities.Encriptar("abcAb2a1.")));
            var search = usuarioRepositorio.FindByEmailAndPass("@gmail.com", Utilities.Encriptar("abcAb2a1."));
            Assert.IsNotType<Usuario>(search);
            Assert.DoesNotContain(search, usuarioRepositorio.FindAll());
            Assert.True(search == null);
        }

        [Fact]
        public async void UsuarioRepositorio_EliminarById()
        {
            var dbContext = await GetDBContext();
            var usuarioRepositorio = new RepositorioUsuarios(dbContext);
            usuarioRepositorio.Delete(1);
            Usuario user = usuarioRepositorio.FindById(1);
            Assert.True(user == null);
        }

        [Fact]
        public async void UsuarioRepositorio_NotEliminarById()
        {
            var dbContext = await GetDBContext();
            var usuarioRepositorio = new RepositorioUsuarios(dbContext);
            Assert.Throws<Exception>(() => { usuarioRepositorio.Delete(10); });
        }

    }
}