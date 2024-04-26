using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_Programacion_3.Models;

namespace Obligatorio_Programacion_3.Controllers
{
    public class ParametroController : Controller
    {
        ICUModificarParametro CUModificarParametro { get; set; }
        ICUObtenerParametroPorNombre CUObtenerParametroPorNombre { get; set; }

        public ParametroController(ICUModificarParametro cUModificarParametro, ICUObtenerParametroPorNombre cUObtenerParametro)
        {
            CUModificarParametro = cUModificarParametro;
            CUObtenerParametroPorNombre = cUObtenerParametro;
        }

        public IActionResult Edit(string nombre)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "Usuario");
            }
            Parametro par = CUObtenerParametroPorNombre.ObtenerParametroPorNombre(nombre);

            return View(new ParametroViewModel() { Id = par.Id, Valor = par.Valor, Nombre = par.Nombre });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ParametroViewModel par)
        {
            if (HttpContext.Session.GetString("emailUsu") == null)
            {
                return RedirectToAction("InicioDeSesion", "Usuario");
            }
            if (ModelState.IsValid)
            {
                CUModificarParametro.ModificarParametro(new Parametro()
                {
                    Id = par.Id,
                    Nombre = par.Nombre,
                    Valor = par.Valor,
                });
            }
            return RedirectToAction(nameof(Edit), routeValues: par.Nombre);
        }
    }
}
