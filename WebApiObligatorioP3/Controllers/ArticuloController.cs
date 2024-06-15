using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public ICUObtenerArticulosOrdenados CUObtenerArticulosOrdenados { get; set; }

        public ArticuloController(ICUObtenerArticulosOrdenados cuObtenerArtuculosOrdenados)
        {
            CUObtenerArticulosOrdenados = cuObtenerArtuculosOrdenados;
        }

        /*
         -https://localhost:7048/api/Articulo/Listado GET
         -https://localhost:7048/api/TipoMovimiento GET
         */

        
        // GET: api/<ArticuloController>
        [HttpGet("Select")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex) 
            {
                return new ContentResult { StatusCode = 500, Content = "Hubo un error" };
            }
        }

        [HttpGet]
        [Route("OrderByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetArticulosOrdenados()
        {
            try
            {
                return Ok(CUObtenerArticulosOrdenados.ObtenerArticulosOrdenados());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Hubo un error en el servidor");
            }

        }
    }
}
