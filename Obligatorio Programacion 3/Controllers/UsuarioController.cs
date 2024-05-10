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

        public ICUModificarUsuario CUModificarUsuario { get; set; }

        public ICUInicioDeSesion CUInicioDeSesion { get; set; }

        public UsuarioController(ICUAltaUsuario cUAltaUsuario, ICUObtenerUsuarios cUObtenerUsuarios, ICUBuscarUsuario cUBuscarUsuario, ICUEliminarUsuario cUEliminarUsuario, ICUModificarUsuario cUModificarUsuario, ICUInicioDeSesion cUInicioDeSesion)
        {
            CUAltaUsuario = cUAltaUsuario;
            CUObtenerUsuarios = cUObtenerUsuarios;
            CUBuscarUsuario = cUBuscarUsuario;
            CUEliminarUsuario = cUEliminarUsuario;
            CUModificarUsuario = cUModificarUsuario;
            CUInicioDeSesion = cUInicioDeSesion;
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
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioVM)
        {
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
                HttpContext.Session.SetString("emailUsu", usuarioVM.Email);
                return RedirectToAction(nameof(Index), "Home");
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
            try
            {
                Usuario usuario = CUBuscarUsuario.BuscarUsuarioPorId(id);
                if (usuario == null)
                {
                    throw new UsuarioException("El usuario con esa id no existe!");
                }
                UsuarioEditViewModel usuarioEditVM = new UsuarioEditViewModel()
                {
                    Id = usuario.Id,
                    Email = usuario.EmailUsuario.Email,
                    Nombre = usuario.NombreUsuario.Nombre,
                    Apellido = usuario.ApellidoUsuario.Apellido,
                    Password = usuario.PasswordUsuario.Password,
                };
                return View(usuarioEditVM);

            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new UsuarioEditViewModel());
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new UsuarioEditViewModel());
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioEditViewModel usuarioEditVM)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction(nameof(InicioDeSesion));
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Datos incorrectos");
                }


                Usuario usuarioAModificar = new Usuario
                {
                    Id = usuarioEditVM.Id,
                    NombreUsuario = new NombreVO(usuarioEditVM.Nombre),
                    ApellidoUsuario = new ApellidoVO(usuarioEditVM.Apellido),
                    PasswordUsuario = new PasswordVO(usuarioEditVM.Password),
                };
                String passwordEncriptada = Utilities.Encriptar(usuarioEditVM.Password);
                usuarioAModificar.PasswordEncriptada = passwordEncriptada;
                CUModificarUsuario.ModificarUsuario(usuarioAModificar);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(usuarioEditVM);
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
                Usuario usuarioBuscado = CUInicioDeSesion.BuscarUsuarioPorEmailYPassword(usuarioLoginVM.Email, usuarioLoginVM.Password);
                if (usuarioBuscado != null)
                {
                    HttpContext.Session.SetString("emailUsu", usuarioLoginVM.Email);
                    return RedirectToAction(nameof(Index), "Home");
                }
                throw new Exception("Credenciales incorrectas");
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(usuarioLoginVM);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(usuarioLoginVM);
            }


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}

