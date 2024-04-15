
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class ClienteController : Controller
    {
        public ICUObtenerClientes CUObtenerClientes { get; set; }

        public ICUBuscarClientesPorMonto CUBuscarClientesPorMonto { get; set; }

        public ClienteController(ICUObtenerClientes cuObtenerClientes, ICUBuscarClientesPorMonto cUBuscarClientesPorMonto)
        {
            CUObtenerClientes = cuObtenerClientes;
            CUBuscarClientesPorMonto = cUBuscarClientesPorMonto;
        }

        public IActionResult Index()
        {
            List<ClienteListadoViewModel> clientes = CUObtenerClientes.ObtenerClientes().Select(c => new ClienteListadoViewModel{
                Id = c.Id,
                RazonSocial = c.RazonSocial,
                RUT = c.RUT,
            }).ToList();
            return View(clientes);
        }

        
        public IActionResult ClientesPorGasto(decimal monto)
        {
            try
            {
                List<ClienteListadoViewModel> clientes = CUBuscarClientesPorMonto.FindClientePorMonto(monto).Select(c => new ClienteListadoViewModel
                {
                    Id = c.Id,
                    RazonSocial = c.RazonSocial,
                    RUT = c.RUT,
                }).ToList(); ;
                return View("Index",clientes);
            }catch (Exception ex)
            {
                ViewBag.Error = "Hubo un error";
                return View();
            }
            
        }

    }
}
