
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class ClienteController : Controller
    {
        public ICUObtenerClientes CUObtenerClientes { get; set; }

        public ICUBuscarClientesPorMonto CUBuscarClientesPorMonto { get; set; }

        public ICUBuscarClientesPorNombre CUBuscarClienterPorNombre { get; set; }

        public ClienteController(ICUObtenerClientes cuObtenerClientes, ICUBuscarClientesPorMonto cUBuscarClientesPorMonto, ICUBuscarClientesPorNombre cUBuscarClienterPorNombre)
        {
            CUObtenerClientes = cuObtenerClientes;
            CUBuscarClientesPorMonto = cUBuscarClientesPorMonto;
            CUBuscarClienterPorNombre = cUBuscarClienterPorNombre;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            List<ClienteListadoViewModel> clientes = CUObtenerClientes.ObtenerClientes().Select(c => new ClienteListadoViewModel
            {
                Id = c.Id,
                RazonSocial = c.RazonSocial,
                RUT = c.RUT,
            }).ToList();
            return View(clientes);
        }


        public IActionResult ClientesPorGasto(decimal monto)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                List<ClienteListadoViewModel> clientes = CUBuscarClientesPorMonto.FindClientePorMonto(monto).Select(c => new ClienteListadoViewModel
                {
                    Id = c.Id,
                    RazonSocial = c.RazonSocial,
                    RUT = c.RUT,
                }).ToList(); ;
                return View("Index", clientes);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Hubo un error";
                return View("Index", new List<ClienteListadoViewModel>());
            }

        }

        public ActionResult ClientesPorNombre(string nombre)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                List<ClienteListadoViewModel> clientes = CUBuscarClienterPorNombre.FindClientesPorNombre(nombre).Select(c => new ClienteListadoViewModel
                {
                    Id = c.Id,
                    RazonSocial = c.RazonSocial,
                    RUT = c.RUT,
                }).ToList(); ;
                return View("Index", clientes);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Hubo un error";
                return View("Index", new List<ClienteListadoViewModel>());
            }
        }

    }
}
