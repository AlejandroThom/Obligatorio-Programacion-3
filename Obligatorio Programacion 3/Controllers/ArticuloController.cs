using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.ValueObjects.ArticulosVO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;
using System.Collections.Immutable;

namespace Obligatorio_Programacion_3.Controllers
{
    public class ArticuloController : Controller
    {
        public ICUObtenerArticulos cUObtenerArticulos { get; set; }
        public ICUBuscarArticulo cUBuscarArticulo { get; set; }

        public ICUAltaArticulo cUAltaArticulo { get; set; }

        public ArticuloController(ICUObtenerArticulos ICUObtenerArts, ICUBuscarArticulo cUBuscarArt, ICUAltaArticulo cuAlta)
        {
            cUObtenerArticulos = ICUObtenerArts;
            cUBuscarArticulo = cUBuscarArt;
            cUAltaArticulo = cuAlta;
        }
        
        // GET: ArticuloController
        public ActionResult Index()
        {
            IEnumerable<Articulo> articulos = cUObtenerArticulos.ObtenerArticulos();
            IEnumerable<ArticuloListadoViewModel> articulosVM = articulos.Select(a => new ArticuloListadoViewModel()
            {
                Id = a.Id,
                CodigoArticulo=a.CodigoArticulo.Codigo,
                Nombre = a.NombreArticulo.Nombre,
                PrecioPublico = a.PrecioPublico,
                Descripcion=a.DescripcionArticulo.Descripcion,
                Stock=a.Stock,
            });
            articulosVM.ToList().Sort();
            return View(articulosVM);
        }


        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloViewModel newArticulo)
        {
            try
            {
                Articulo articuloNuevo = new Articulo() {
                    NombreArticulo = new NombreVO(newArticulo.Nombre),
                    DescripcionArticulo = new DescripcionVO(newArticulo.Descripcion),
                    CodigoArticulo = new CodigoVO(newArticulo.Codigo),
                    PrecioPublico = newArticulo.PrecioPublico,
                    Stock = newArticulo.Stock,
                };
                cUAltaArticulo.AltaArticulo(articuloNuevo);
                return RedirectToAction(nameof(Index));
            }
            catch (ArticuloException excep)
            {
                ViewBag.Mensaje = excep.Message;
                return View(newArticulo);
            }
            catch
            {
                ViewBag.Mensaje = "Hubo un error al crear un nuevo artículo";
                return View(newArticulo);
            }
        }

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
