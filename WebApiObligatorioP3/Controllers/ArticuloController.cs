using LogicaAplicacion.CasosUso.CUArticulo.Implementacion;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.Articulo;
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
        public ICUObtenerArticulosParaSeleccion CUObtenerArticulosParaSeleccion { get; set; }
        public ICUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos 
            CUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos { get; set; }
        public ICUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento CUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento { get; set; }

        public ArticuloController(ICUObtenerArticulosOrdenados cuObtenerArtuculosOrdenados,
             ICUObtenerArticulosParaSeleccion cUObtenerArticulosParaSeleccion,
             ICUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos cUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos
            , ICUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento cUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento )
        {
            CUObtenerArticulosOrdenados = cuObtenerArtuculosOrdenados;
            CUObtenerArticulosParaSeleccion = cUObtenerArticulosParaSeleccion;
            CUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento = cUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento;
            CUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos = cUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos;
        }


        [HttpGet("Busqueda/{inicio:datetime}/{fin:datetime}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerCantidadArticuloPorFechas(DateTime inicio, DateTime fin)
        {
            try
            {
                return Ok(CUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento.ObtenerCantidadArticulosPorMovimientosDeStockEntreDosFechas(inicio, fin));
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = "Hubo un error al obtener los datos", StatusCode = 500 };
            }
        }


        /// <summary>
        /// Dado un dos fecha y una pagina, filtra a los articulos que tuvieron al menos un
        /// movimiento entre esas fechas
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <param name="pagina"></param>
        /// <returns>Devuelve un maximo de 5 articulos por pagina</returns>
        [HttpGet("Busqueda/{inicio:datetime}/{fin:datetime}/{pagina:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerArticuloPorFechas(DateTime inicio,DateTime fin,int pagina)
        {
            try
            {
                if (pagina <= 0) throw new ParamException("Pagina no valida");
                return Ok(CUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos.ObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos(inicio,fin,pagina));
            }
            catch(ParamException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArticuloException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex) 
            {
                return new ContentResult { Content="Hubo un error al obtener los datos",StatusCode=500};
            }
        }

        
        // GET: api/<ArticuloController>
        [HttpGet("Select")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUObtenerArticulosParaSeleccion.ObtenerArticulosParaSeleccion());
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
