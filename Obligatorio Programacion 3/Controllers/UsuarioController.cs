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

        public UsuarioController(ICUAltaUsuario cUAltaUsuario, ICUObtenerUsuarios cUObtenerUsuarios)
        {
            CUAltaUsuario = cUAltaUsuario;
            CUObtenerUsuarios = cUObtenerUsuarios;
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            IEnumerable<Usuario> usuarios = CUObtenerUsuarios.ObtenerUsuarios();
            IEnumerable<UsuarioListadoViewModel> usuarioVM = usuarios.Select(u => new UsuarioListadoViewModel()
            {
                Id = u.Id ,
                Email = u.Email,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
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
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
