using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.ValueObjects.ArticulosVO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class PedidoController : Controller
    {
        public ICUObtenerClientes cUObtenerClientes { get; set; }
        public ICUObtenerArticulos cUObtenerArticulos { get; set; }

        public PedidoController(ICUObtenerClientes cuObtenerClientes,ICUObtenerArticulos cuObtenerArticulos)
        {
            cUObtenerClientes = cuObtenerClientes;
            cUObtenerArticulos = cuObtenerArticulos;
        }

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
            IEnumerable<ClienteListadoViewModel> clientes = cUObtenerClientes.ObtenerClientes()
                .Select(c => 
                 new ClienteListadoViewModel() { Id = c.Id, RazonSocial = c.RazonSocial  })
                .ToList().Prepend(new ClienteListadoViewModel() { RazonSocial="Seleccione un cliente"});
            ViewData["Clientes"] = new SelectList(clientes, "Id", "RazonSocial");
            IEnumerable<ArticuloSelectViewModel> articulos = cUObtenerArticulos.ObtenerArticulos()
                .Select(a=> new ArticuloSelectViewModel() 
                { Id=a.Id,Nombre=a.NombreArticulo.Nombre})
                .ToList().Prepend(new ArticuloSelectViewModel() { Nombre="Seleccione un articulo"});
            ViewData["Articulos"] = new SelectList(articulos, "Id", "Nombre");
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
