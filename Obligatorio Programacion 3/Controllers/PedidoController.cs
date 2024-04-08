using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.ValueObjects.ArticulosVO;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscarPorFecha(DateTime fecha)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel newPedido)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch (PedidoException excep)
            {
                ViewBag.Mensaje = excep.Message;
                return View(newPedido);
            }
            catch
            {
                ViewBag.Mensaje = "Hubo un error al crear un nuevo pedido";
                return View(newPedido);
            }
        }

        public ActionResult Anular(int id)
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Anular()
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch (PedidoException excep)
            {
                ViewBag.Mensaje = excep.Message;
                return View();
            }
            catch
            {
                ViewBag.Mensaje = "Hubo un error al crear un nuevo artículo";
                return View();
            }
        }


    }
}
