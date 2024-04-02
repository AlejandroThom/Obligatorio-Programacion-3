using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class ClienteController : Controller
    {
        public ICUAltaCliente CUAltaCliente { get; set; }
        public ICUObtenerClientes CUObtenerClientes { get; set; }

        public ClienteController(ICUAltaCliente cuAltaCliente, ICUObtenerClientes cUObtenerClientes)
        {
            CUAltaCliente = cuAltaCliente;
            CUObtenerClientes = cUObtenerClientes;
        }
        // GET: ClienteController
        public ActionResult Index()
        {
            IEnumerable<Cliente> cliente = CUObtenerClientes.ObtenerClientes();
            IEnumerable<ClienteListadoViewModel> clienteVM = cliente.Select(c => new ClienteListadoViewModel()
            {
                RazonSocial = c.RazonSocial,
                RUT = c.RUT,
            }).ToList();

            return View(clienteVM);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteVM)
        {
            try
            {
                if(clienteVM == null)
                {
                    throw new Exception("Datos incorrectos");
                }
                Direccion direccion = new Direccion
                {
                    Calle = clienteVM.Calle,
                    Numero = clienteVM.Numero,
                    Ciudad = clienteVM.Ciudad,
                };

                Cliente cliente = new Cliente()
                {
                    
                    RazonSocial = clienteVM.RazonSocial,
                    RUT = clienteVM.RUT,
                    Direccion = direccion,
                    DistanciaPapeleria = clienteVM.DistanciaPapeleria,
                };

                CUAltaCliente.AltaCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch (ClienteException ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
