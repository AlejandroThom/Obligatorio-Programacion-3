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


        [HttpGet("BusquedaCantidad/{inicio}/{fin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObtenerCantidadArticuloPorFechas(string inicio, string fin)
        {
            try
            {
                string[] fecha = inicio.Split("-");
                string[] fecha2 = fin.Split("-");
                DateTime iniciofecha = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]));
                DateTime inicioFin = new DateTime(int.Parse(fecha2[2]), int.Parse(fecha2[1]), int.Parse(fecha2[0]));
                return Ok(CUObtenerCantidadDeArticulosEntreDosFechasDeMovimiento.ObtenerCantidadArticulosPorMovimientosDeStockEntreDosFechas(iniciofecha, inicioFin));
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
        [HttpGet("Busqueda/{inicio}/{fin}/{pagina:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerArticuloPorFechas(string inicio,string fin,int pagina)
        {
            try
            {
                if (pagina <= 0) throw new ParamException("Pagina no valida");
                string[] fecha = inicio.Split("-");
                string[] fecha2 = fin.Split("-");
                DateTime iniciofecha = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]));
                DateTime inicioFin = new DateTime(int.Parse(fecha2[2]), int.Parse(fecha2[1]), int.Parse(fecha2[0]));
                return Ok(CUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos.ObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos(iniciofecha, inicioFin, pagina));
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
