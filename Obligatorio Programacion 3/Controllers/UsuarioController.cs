using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.Utils;
using LogicaNegocio.ValueObjects.UsuarioVO;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class UsuarioController : Controller
    {
        public ICUAltaUsuario CUAltaUsuario { get; set; }
        public ICUObtenerUsuarios CUObtenerUsuarios { get; set; }

        public ICUBuscarUsuario CUBuscarUsuario { get; set; }

        public ICUEliminarUsuario CUEliminarUsuario { get; set; }

        public UsuarioController(ICUAltaUsuario cUAltaUsuario, ICUObtenerUsuarios cUObtenerUsuarios, ICUBuscarUsuario cUBuscarUsuario, ICUEliminarUsuario cUEliminarUsuario)
        {
            CUAltaUsuario = cUAltaUsuario;
            CUObtenerUsuarios = cUObtenerUsuarios;
            CUBuscarUsuario = cUBuscarUsuario;
            CUEliminarUsuario = cUEliminarUsuario;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            IEnumerable<Usuario> usuarios = CUObtenerUsuarios.ObtenerUsuarios();
            IEnumerable<UsuarioListadoViewModel> usuarioVM = usuarios.Select(u => new UsuarioListadoViewModel()
            {
                Id = u.Id,
                Email = u.EmailUsuario,
                Nombre = u.NombreUsuario,
                Apellido = u.ApellidoUsuario,
            }).ToList();

            return View(usuarioVM);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioVM)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            try
            {
                if (usuarioVM == null)
                {
                    throw new Exception("Datos incorrectos");
                }
                Usuario usuario = new Usuario()
                {
                    EmailUsuario = new EmailVO(usuarioVM.Email),
                    NombreUsuario = new NombreVO(usuarioVM.Nombre),
                    ApellidoUsuario = new ApellidoVO(usuarioVM.Apellido),
                    PasswordUsuario = new PasswordVO(usuarioVM.Password),
                    PasswordEncriptada = Utilities.Encriptar(usuarioVM.Password),
                };
                CUAltaUsuario.AltaUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (ClienteException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }

            //Busqueda del usuario desde el viewModel y colocarlo en pantalla
            // Crear vm UsuarioEditViewModel tendra el Id, nombre, apellido y pass
            // Modificar en la vista al final agregar el id para la navegacion.
            // BuscarUsuarioPorId.
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioEditViewModel usuarioEditVM)
        {
            if(HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            //modificacion de usuario nombre apellido y contrasenia
            //Agregar en todos los metodos que tienen que estar logueados para poder realizarlos
            //Agregar en el resto de los controladores la verificacion de la variable de sesion 
            // crear un nuevo usuario y pasarle todos los datos del vm
            //llamar al caso de uso de editar (inyeccion de dependencia)
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            try
            {
                Usuario usuarioBuscado = CUBuscarUsuario.BuscarUsuarioPorId(id);
                if (usuarioBuscado == null)
                {
                    throw new Exception("No existe un usuario con ese id");
                }
                UsuarioListadoViewModel usuarioVM = new UsuarioListadoViewModel()
                {
                    Id = usuarioBuscado.Id,
                    Nombre = usuarioBuscado.NombreUsuario,
                    Apellido = usuarioBuscado.ApellidoUsuario,
                };
                return View(usuarioVM);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new UsuarioListadoViewModel());
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioListadoViewModel usuarioVM)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }
            try
            {
                CUEliminarUsuario.EliminarUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(usuarioVM);
            }
        }
        //GET Login
        public IActionResult InicioDeSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InicioDeSesion(UsuarioLoginViewModel usuarioLoginVM)
        {

            try
            {
                usuarioLoginVM.Password = Utilities.Encriptar(usuarioLoginVM.Password);
                Usuario usuarioBuscado = CUBuscarUsuario.BuscarUsuarioPorEmailYPassword(usuarioLoginVM.Email, usuarioLoginVM.Password);
                if (usuarioBuscado != null)
                {
                    HttpContext.Session.SetString("emailUsu", usuarioBuscado.EmailUsuario.ToString());
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                ViewBag.Mensaje = "Datos incorrectos";
                return View(usuarioLoginVM);

                }
            }
            catch (UsuarioException ex) 
            {
                ViewBag.Mensaje = ex.Message;
                return View(usuarioLoginVM);

            }


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index),"Home");
        }
    }
}

