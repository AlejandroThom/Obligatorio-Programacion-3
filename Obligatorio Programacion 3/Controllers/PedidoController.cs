using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaAplicacion.CasosUso.CUParametro.Implementacion;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
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

        public PedidoController(ICUObtenerClientes cuObtenerClientes,
            ICUObtenerArticulos cuObtenerArticulos,
            ICUAltaPedido cUAltaPedido,
            ICUBuscarArticulo cuBuscarArticulo,
            ICUBuscarClientePorId cUBuscarClientePorId,
            ICUObtenerPedidos cuObtenerPedidos,
            ICUObtenerParametroPorNombre cuObtenerParametroPorNombre,
            ICUObtenerPedidosPorFecha cuObtenerPedidosPorFecha,
            ICUBuscarPedido cuBuscarPedido,
            ICUAnularPedido cuAnularPedido
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
        }

        #endregion
        public IActionResult Index()
        {
            IEnumerable<PedidoListadoViewModel> pedidos = CUObtenerPedidos.ObtenerPedidos().Select(p => new PedidoListadoViewModel()
            {
                Id= p.Id,
                Cliente = p.Cliente,
                FechaEntrega = p.FechaEntrega,
                FechaPedido = p.FechaPedido,
                Precio = p.PrecioPedidoFinal,
            }).ToList();
            return View(pedidos);
        }

        public IActionResult BuscarPedidoPorFecha(DateTime fecha)
        {
            IEnumerable<PedidoListadoViewModel> pedidos = CUObtenerPedidosPorFecha.ObtenerPedidosPorFecha(fecha).Select(
                p=>new PedidoListadoViewModel() {
                    Id = p.Id,
                    Cliente = p.Cliente,Precio=p.PrecioPedidoFinal,
                    FechaEntrega=p.FechaEntrega,FechaPedido=p.FechaPedido
                }
                ).ToList();
            return View("Index",pedidos);
        }

        public ActionResult Create()
        {
            IEnumerable<ClienteListadoViewModel> clientes = ListadoClienteViewModel();
            ViewData["Clientes"] = new SelectList(clientes, "Id", "RazonSocial");
            IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
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
                if(ModelState.IsValid)
                {
                    Pedido pedido;
                    Articulo art = CUObtenerArticulo.BuscarArticuloPorId(newPedido.ArticuloId);
                    Linea nuevaLin = new Linea() { 
                        CantArticulo = newPedido.CantidadArticulo,
                        Articulo = art,
                        PrecioUnitario = art.PrecioPublico,
                    };
                    Cliente cliente = CUBuscarClientePorId.BuscarClientePorId(newPedido.ClienteId);
                    if (newPedido.IsEnvioExpress)
                    {
                        pedido = new PedidoExpress()
                        {
                            FechaEntrega = newPedido.FechaEntrega,
                            FechaPedido = DateTime.Now,
                            Cliente = cliente,
                            IsAnulado = false,
                        };
                    }
                    else
                    {
                        pedido = new PedidoComun()
                        {
                            FechaEntrega = newPedido.FechaEntrega,
                            FechaPedido = DateTime.Now,
                            Cliente = cliente,
                            IsAnulado = false,
                        };
                    }
                    pedido.Lineas.Add(nuevaLin);
                    pedido.PrecioPedidoFinal = pedido.PrecioFinal(CUObtenerParametroPorNombre.ObtenerParametroPorNombre("IVA"));
                    CUAltaPedido.AltaPedido(pedido);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Create));
            }
            catch (PedidoException excep)
            {
                IEnumerable<ClienteListadoViewModel> clientes = ListadoClienteViewModel();
                ViewData["Clientes"] = new SelectList(clientes, "Id", "RazonSocial");
                IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
                ViewData["Articulos"] = new SelectList(articulos, "Id", "Nombre");
                ViewBag.Mensaje = excep.Message;
                return View(newPedido);
            }
            catch
            {
                IEnumerable<ClienteListadoViewModel> clientes = ListadoClienteViewModel();
                ViewData["Clientes"] = new SelectList(clientes, "Id", "RazonSocial");
                IEnumerable<ArticuloSelectViewModel> articulos = SelectArticuloViewModel();
                ViewData["Articulos"] = new SelectList(articulos, "Id", "Nombre");
                ViewBag.Mensaje = "Hubo un error al crear un nuevo pedido";
                return View(newPedido);
            }
        }

        public ActionResult Anular(int id)
        {
            Pedido ped = CUBuscarPedido.BuscarPedidoPorId(id);
            PedidoListadoViewModel pedidoListadoViewModel = new PedidoListadoViewModel() {
                Id= ped.Id,
                FechaEntrega=ped.FechaEntrega,
                Cliente=ped.Cliente,
                Precio = ped.PrecioPedidoFinal,
                FechaPedido = ped.FechaPedido
            };
            return View(pedidoListadoViewModel);
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Anular(int id,PedidoListadoViewModel pedidoLVM)
        {
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

        public IEnumerable<ClienteListadoViewModel> ListadoClienteViewModel()
        {
            return cUObtenerClientes.ObtenerClientes()
                .Select(c =>
                 new ClienteListadoViewModel() { Id = c.Id, RazonSocial = c.RazonSocial })
                .ToList().Prepend(new ClienteListadoViewModel() { RazonSocial = "Seleccione un cliente" });
        }

        public IEnumerable<ArticuloSelectViewModel> SelectArticuloViewModel()
        {
            return cUObtenerArticulos.ObtenerArticulos()
                    .Select(a => new ArticuloSelectViewModel()
                    { Id = a.Id, Nombre = a.NombreArticulo.Nombre })
                    .ToList().Prepend(new ArticuloSelectViewModel() { Nombre = "Seleccione un articulo" });
        }
    }
}
