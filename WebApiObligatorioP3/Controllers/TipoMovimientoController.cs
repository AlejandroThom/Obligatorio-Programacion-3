using DTO;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaNegocio.Excepciones.TipoMovimiento;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        public ICUAltaTipoMovimiento CUAltaTipoMovimiento { get; set; }
        public ICUActualizarTipoMovimiento CUActualizarTipoMovimiento { get; set; }
        public ICUEliminarTipoMovimiento CUEliminarTipoMovimiento { get; set; }
        public ICUObtenerTipoMovimientoPorId CUObtenerTipoMovimientoPorId { get; set; }
        public ICUObtenerTiposDeMovimiento CUObtenerTiposDeMovimiento { get; set; }

        public TipoMovimientoController(ICUAltaTipoMovimiento cUAltaTipoMovimiento, ICUActualizarTipoMovimiento cUActualizarTipoMovimiento, ICUEliminarTipoMovimiento cUEliminarTipoMovimiento, ICUObtenerTipoMovimientoPorId cUObtenerTipoMovimientoPorId, ICUObtenerTiposDeMovimiento cUObtenerTiposDeMovimiento)
        {
            CUAltaTipoMovimiento = cUAltaTipoMovimiento;
            CUActualizarTipoMovimiento = cUActualizarTipoMovimiento;
            CUEliminarTipoMovimiento = cUEliminarTipoMovimiento;
            CUObtenerTipoMovimientoPorId = cUObtenerTipoMovimientoPorId;
            CUObtenerTiposDeMovimiento = cUObtenerTiposDeMovimiento;
        }

        // GET: api/<TipoMovimientoController>
        /// <summary>
        /// Recupera todos los tipos de movimiento
        /// </summary>
        /// <returns>Una lista de todos los tipos de movimiento</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                return Ok(CUObtenerTiposDeMovimiento.ObtenerTiposDeMovimiento());
            }
            catch
            {
                return new ContentResult{StatusCode=500,
                    Content="Hubo un error al obtener los tipos de movimiento",
                    ContentType="text/plain" };
            }
        }

        // GET api/<TipoMovimientoController>/5
        /// <summary>
        /// Recupera un Tipo de Movimiento especifico dado un id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(CUObtenerTipoMovimientoPorId.ObtenerTipoMovimientoPorId(id));
            }
            catch(TipoMovimientoException ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = ex.Message,
                    ContentType = "text/plain"
                };
            }
            catch
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = "Hubo un error al obtener el tipo de movimiento",
                    ContentType = "text/plain"
                };
            }
        }

        // POST api/<TipoMovimientoController>
        /// <summary>
        /// Crea un nuevo Tipo de Movimiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] TipoMovimientoDTO item)
        {
            try
            {
                CUAltaTipoMovimiento.AltaTipoMovimiento(item);
                return Created();
            }
            catch (TipoMovimientoException ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = ex.Message,
                    ContentType = "text/plain"
                };
            }
            catch
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = "Hubo un error al crear el tipo de movimiento",
                    ContentType = "text/plain"
                };
            }

        }

        // PUT api/<TipoMovimientoController>/5
        /// <summary>
        /// Actualiza un Tipo de Movimiento dado su id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] TipoMovimientoDTO item)
        {
            try
            {
                item.Id = id;
                CUActualizarTipoMovimiento.ActualizarTipoMovimiento(item);
                return Ok(item);
            }
            catch (TipoMovimientoException ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = ex.Message,
                    ContentType = "text/plain"
                };
            }
            catch
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = "Hubo un error al actualizar el tipo de movimiento",
                    ContentType = "text/plain"
                };
            }
        }

        // DELETE api/<TipoMovimientoController>/5
        /// <summary>
        /// Elimina un tipo de movimiento dado su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                CUEliminarTipoMovimiento.EliminarTipoMovimiento(id);
                return NoContent();
            }
            catch (TipoMovimientoException ex)
            {
                return new ContentResult
                {
                    StatusCode = 400,
                    Content = ex.Message,
                    ContentType = "text/plain"
                };
            }
            catch
            {
                return new ContentResult
                {
                    StatusCode = 500,
                    Content = "Hubo un error al eliminar el tipo de movimiento",
                    ContentType = "text/plain"
                };
            }
        }
    }
}
