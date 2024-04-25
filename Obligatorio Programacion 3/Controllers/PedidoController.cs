using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Linea;
using LogicaNegocio.Excepciones.Pedido;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class PedidoController : Controller
    {
        #region InyeccionDependencias
        public ICUObtenerClientes cUObtenerClientes { get; set; }
        public ICUObtenerArticulos cUObtenerArticulos { get; set; }
        public ICUBuscarArticulo CUObtenerArticulo { get; set; }
        public ICUAltaPedido CUAltaPedido { get; set; }
        public ICUBuscarClientePorId CUBuscarClientePorId { get; set; }
        public ICUObtenerPedidos CUObtenerPedidos { get; set; }
        public ICUObtenerParametroPorNombre CUObtenerParametroPorNombre { get; set; }
        public ICUObtenerPedidosPorFecha CUObtenerPedidosPorFecha { get; set; }
        public ICUBuscarPedido CUBuscarPedido { get; set; }
        public ICUAnularPedido CUAnularPedido { get; set; }
        public ICUAgregarLinea CUAgregarLinea { get; set; }

        public PedidoController(ICUObtenerClientes cuObtenerClientes,
            ICUObtenerArticulos cuObtenerArticulos,
            ICUAltaPedido cUAltaPedido,
            ICUBuscarArticulo cuBuscarArticulo,
            ICUBuscarClientePorId cUBuscarClientePorId,
            ICUObtenerPedidos cuObtenerPedidos,
            ICUObtenerParametroPorNombre cuObtenerParametroPorNombre,
            ICUObtenerPedidosPorFecha cuObtenerPedidosPorFecha,
            ICUBuscarPedido cuBuscarPedido,
            ICUAnularPedido cuAnularPedido,
            ICUAgregarLinea cuAgregarLinea
            )
        {
            cUObtenerClientes = cuObtenerClientes;
            cUObtenerArticulos = cuObtenerArticulos;
            CUAltaPedido = cUAltaPedido;
            CUObtenerArticulo = cuBuscarArticulo;
            CUBuscarClientePorId = cUBuscarClientePorId;
            CUObtenerPedidos = cuObtenerPedidos;
            CUObtenerParametroPorNombre = cuObtenerParametroPorNombre;
            CUObtenerPedidosPorFecha = cuObtenerPedidosPorFecha;
            CUBuscarPedido = cuBuscarPedido;
            CUAnularPedido = cuAnularPedido;
            CUAgregarLinea = cuAgregarLinea;
        }

        #endregion
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            IEnumerable<PedidoListadoViewModel> pedidos = CUObtenerPedidos.ObtenerPedidos().Select(p => new PedidoListadoViewModel()
            {
                Id = p.Id,
                Cliente = p.Cliente,
                FechaEntrega = p.FechaEntrega,
                FechaPedido = p.FechaPedido,
                Precio = p.PrecioPedidoFinal,
                IsAnulado = p.IsAnulado,
            }).ToList();
            return View(pedidos);
        }

        public IActionResult BuscarPedidoPorFecha(DateTime fecha)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            IEnumerable<PedidoListadoViewModel> pedidos = CUObtenerPedidosPorFecha.ObtenerPedidosPorFecha(fecha.Date).Select(
                p => new PedidoListadoViewModel()
                {
                    Id = p.Id,
                    Cliente = p.Cliente,
                    Precio = p.PrecioPedidoFinal,
                    FechaEntrega = p.FechaEntrega,
                    FechaPedido = p.FechaPedido,
                    IsAnulado = p.IsAnulado,
                }
                ).ToList();
            return View("Index", pedidos);
        }

        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            IEnumerable<ClienteSelectViewModel> clientes = ListadoClienteViewModel();
            ViewData["Clientes"] = new SelectList(clientes, "Id", "Informacion");
            IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
            ViewData["Articulos"] = new SelectList(articulos, "Id", "Informacion");
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel newPedido)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    Pedido pedido;
                    Articulo art = CUObtenerArticulo.BuscarArticuloPorId(newPedido.ArticuloId);
                    Linea nuevaLin = new Linea()
                    {
                        CantArticulo = newPedido.CantidadArticulo,
                        Articulo = art,
                        PrecioUnitario = art.PrecioPublico,
                    };
                    if ((newPedido.FechaEntrega - DateTime.Now).TotalDays <= 5)
                    {
                        pedido = new PedidoExpress();
                    }
                    else
                    {
                        pedido = new PedidoComun();
                    }
                    pedido.FechaEntrega = newPedido.FechaEntrega;
                    pedido.FechaPedido = DateTime.Now;
                    pedido.Cliente = new Cliente() { Id = newPedido.ClienteId };
                    pedido.IsAnulado = false;
                    pedido.Lineas.Add(nuevaLin);
                    pedido.AsignarPrecioFinal(CUObtenerParametroPorNombre.ObtenerParametroPorNombre("IVA").Valor);
                    CUAltaPedido.AltaPedido(pedido);
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception("Error modelo no valido");
            }
            catch (PedidoException excep)
            {
                ViewBag.Mensaje = excep.Message;
            }
            catch
            {
                ViewBag.Mensaje = "Hubo un error al crear un nuevo pedido";
            }
            IEnumerable<ClienteSelectViewModel> clientes = ListadoClienteViewModel();
            ViewData["Clientes"] = new SelectList(clientes, "Id", "Informacion");
            IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
            ViewData["Articulos"] = new SelectList(articulos, "Id", "Informacion");
            return View(newPedido);

        }

        [HttpGet]
        public ActionResult AgregarLinea(int id)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                Pedido ped = CUBuscarPedido.BuscarPedidoPorId(id);
                ped.IsPedidoModificable();
                ArticuloPedidoViewModel articuloPedidoViewModel = new ArticuloPedidoViewModel()
                {
                    IsEnvioExpress = ped is PedidoExpress,
                    Cliente = new ClienteListadoViewModel() { RazonSocial = ped.Cliente.RazonSocial },
                    FechaEntrega = ped.FechaEntrega,
                    IdPedido = id
                };
                IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
                ViewBag.Articulos = new SelectList(articulos, "Id", "Informacion");
                return View(articuloPedidoViewModel);

            }
            catch (PedidoException pedEx)
            {
                ViewBag.Mensaje = pedEx.Message;
                return View(new ArticuloPedidoViewModel());
            }
            catch (Exception excep)
            {
                ViewBag.Mensaje = "Hubo un error";
                return View(new ArticuloPedidoViewModel());
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarLinea(ArticuloPedidoViewModel aPedidoVM)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                Articulo art = CUObtenerArticulo.BuscarArticuloPorId(aPedidoVM.IdArticulo);
                Linea linea = new Linea()
                {
                    Articulo = art,
                    CantArticulo = aPedidoVM.CantidadArticulo,
                    PrecioUnitario = art.PrecioPublico
                };
                CUAgregarLinea.AgregarLinea(aPedidoVM.IdPedido, linea);
                if (aPedidoVM.AgregarOtroArticulo)
                    return RedirectToAction(nameof(AgregarLinea), aPedidoVM.IdPedido);
                return RedirectToAction(nameof(Details), aPedidoVM.IdPedido);

            }
            catch (PedidoException peEx)
            {
                //TODO: Cambiar el viewbag por TempData y redirigirlo al método Get si el id es distinto de 0.

                ViewBag.Mensaje = peEx.Message;
            }
            catch (LineaException liEx)
            {
                //TODO: Cambiar el viewbag por TempData y redirigirlo al método Get si el id es distinto de 0.

                ViewBag.Mensaje = liEx.Message;
            }
            catch (Exception ex)
            {
                //TODO: Cambiar el viewbag por TempData y redirigirlo al método Get si el id es distinto de 0.
                ViewBag.Mensaje = "Hubo un error al agregar la linea";
            }
            IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
            ViewBag.Articulos = new SelectList(articulos, "Id", "Informacion");
            return View(new ArticuloPedidoViewModel());

        }

        public ActionResult Anular(int id)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                Pedido ped = CUBuscarPedido.BuscarPedidoPorId(id);
                ped.IsPedidoModificable();
                PedidoListadoViewModel pedidoListadoViewModel = new PedidoListadoViewModel()
                {
                    Id = ped.Id,
                    FechaEntrega = ped.FechaEntrega,
                    Cliente = ped.Cliente,
                    Precio = ped.PrecioPedidoFinal,
                    FechaPedido = ped.FechaPedido,

                };
                return View(pedidoListadoViewModel);
            }
            catch (PedidoException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View(new PedidoListadoViewModel());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewData["Mensaje"] = "Hubo un error al cargar el pedido";
                return View(new PedidoListadoViewModel());
            }

        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Anular(int id, PedidoListadoViewModel pedidoLVM)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            try
            {
                CUAnularPedido.AnularPedido(id);
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

        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "UsuarioController");
            }
            Pedido ped = CUBuscarPedido.BuscarPedidoPorId(id);
            List<LineaListadoViewModel> lineasLVM = ped.Lineas.Select(p => new LineaListadoViewModel()
            {
                CantidadArticulo = p.CantArticulo,
                NombreArticulo = p.Articulo.NombreArticulo.Nombre,
                PrecioTotal = p.PrecioTotal()
            }).ToList();
            PedidoDetailsViewModel details = new PedidoDetailsViewModel()
            {
                Cliente = ped.Cliente.RazonSocial,
                FechaEntrega = ped.FechaEntrega,
                FechaPedido = ped.FechaPedido,
                Id = id,
                Lineas = lineasLVM,
                PrecioPedidoFinal = ped.PrecioPedidoFinal,
                IsAnulado = ped.IsAnulado
            };
            return View(details);
        }


        public IEnumerable<ClienteSelectViewModel> ListadoClienteViewModel()
        {

            return cUObtenerClientes.ObtenerClientes()
                .Select(c =>
                 new ClienteSelectViewModel() { Id = c.Id, Informacion = c.RazonSocial })
                .ToList().Prepend(new ClienteSelectViewModel() { Informacion = "Seleccione un cliente" });
        }

        public IEnumerable<ArticuloSelectViewModel> SelectArticuloViewModel()
        {

            return cUObtenerArticulos.ObtenerArticulos()
                    .Select(a => new ArticuloSelectViewModel()
                    { Id = a.Id, Informacion = $"{a.NombreArticulo.Nombre} - {a.PrecioPublico}" })
                    .ToList().Prepend(new ArticuloSelectViewModel() { Informacion = "Seleccione un articulo" });
        }
    }
}
