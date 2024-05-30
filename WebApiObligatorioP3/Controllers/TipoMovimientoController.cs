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
        [HttpGet]
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
        [HttpGet("{id}")]
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
                    StatusCode = 500,
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
        [HttpPost]
        public IActionResult Post([FromBody] TipoMovimientoDTO item)
        {
            try
            {
                CUAltaTipoMovimiento.AltaTipoMovimiento(item);
                return Ok(item);
            }
            catch (TipoMovimientoException ex)
            {
                return new ContentResult
                {
                    StatusCode = 500,
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoMovimientoDTO item)
        {
            try
            {
                CUActualizarTipoMovimiento.ActualizarTipoMovimiento(item);
                return Ok(item);
            }
            catch (TipoMovimientoException ex)
            {
                return new ContentResult
                {
                    StatusCode = 500,
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
        [HttpDelete("{id}")]
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
                    StatusCode = 500,
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
