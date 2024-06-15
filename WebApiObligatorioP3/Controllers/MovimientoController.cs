using DTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.MovimientoStock;
using LogicaNegocio.Excepciones.TipoMovimiento;
using LogicaNegocio.Excepciones.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {

        /// <summary>
        /// Realiza la creacion de un nuevo movimiento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("RealizarMovimiento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RealizarMovimiento([FromBody] MovimientoCreateDTO dto)
        {
            try
            {
                if (dto.IdArticulo == 0) throw new ArticuloException("El articulo no existe");
                if (string.IsNullOrEmpty(dto.EmailUsaurio)) throw new UsuarioException("El email no es valido");
                if (dto.TipoMovimientoId == 0) throw new TipoMovimientoException("El tipo de movimiento no existe");
                //FALTA OBTENER EL ID DEL USUARIO - SE TIENE SOLO EL EMAIL
                MovimientosStock movimiento = new MovimientosStock() {
                    FechaMovimiento= new DateOnly(dto.FechaRealizacion.Year,dto.FechaRealizacion.Month, dto.FechaRealizacion.Day),
                    HoraMovimiento= new TimeOnly(dto.FechaRealizacion.Ticks),
                    CantidadEnMovimiento = dto.CantidadArticulo,
                    ArticuloMovimiento = new Articulo() { Id=dto.IdArticulo},
                    TipoDeMovimiento = new TipoMovimiento() { Id=dto.TipoMovimientoId},
                    UsuarioEncargado = new Usuario() {Id = 1}
                };

                //ENVIAR AL CASO DE USO

                return Created();
            }catch(MovimientoStockException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return new ContentResult { Content="Hubo un error",StatusCode = 500};
            }
        }

    }
}
