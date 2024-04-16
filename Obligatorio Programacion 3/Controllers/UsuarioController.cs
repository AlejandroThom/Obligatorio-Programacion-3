using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Utils;
using LogicaNegocio.Excepciones.Cliente;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;
using LogicaNegocio.ValueObjects.UsuarioVO;

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
            IEnumerable<Usuario> usuarios = CUObtenerUsuarios.ObtenerUsuarios();
            IEnumerable<UsuarioListadoViewModel> usuarioVM = usuarios.Select(u => new UsuarioListadoViewModel()
            {
                Id = u.Id ,
                Email = u.EmailUsuario,
                Nombre = u.NombreUsuario,
                Apellido = u.ApellidoUsuario,
            }).ToList();

            return View(usuarioVM);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
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
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
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
            try
            {
            Usuario usuarioBuscado = CUBuscarUsuario.BuscarUsuarioPorId(id);
            if(usuarioBuscado == null)
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
            catch(Exception ex)
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InicioDeSesion()
        {
            return View();
        }
    }
}
