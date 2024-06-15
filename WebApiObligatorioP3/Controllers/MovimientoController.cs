using DTO;
using LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.MovimientoStock;
using LogicaNegocio.Excepciones.Params;
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
        public ICUBuscarUsuarioPorEmail CUBuscarUsuarioPorEmail {  get; set; }
        public ICUAltaMovimientoStock CUAltaMovimientoStock { get; set; }
        public ICUObtenerTipoMovimientoPorId CUObtenerTipoMovimientoPorId { get; set; }
        public ICUObtenerParametroPorNombre CUObtenerParametroPorNombre { get; set; }

        public MovimientoController(ICUBuscarUsuarioPorEmail cuBuscarUsuarioPorEmail,
            ICUAltaMovimientoStock cUAltaMovimientoStock,
            ICUObtenerTipoMovimientoPorId cUObtenerTipoMovimientoPorId,
            ICUObtenerParametroPorNombre cUObtenerParametroPorNombre)
        {
            CUBuscarUsuarioPorEmail = cuBuscarUsuarioPorEmail;
            CUAltaMovimientoStock = cUAltaMovimientoStock;
            CUObtenerTipoMovimientoPorId = cUObtenerTipoMovimientoPorId;
            CUObtenerParametroPorNombre = cUObtenerParametroPorNombre;
        }



        /// <summary>
        /// Realiza la creacion de un nuevo movimiento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("RealizarMovimiento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Encargado de depósito")]
        public IActionResult RealizarMovimiento([FromBody] MovimientoCreateDTO dto)
        {
            try
            {
                if (dto.IdArticulo == 0) throw new ArticuloException("El articulo no existe");
                if (string.IsNullOrEmpty(dto.EmailUsuario)) throw new UsuarioException("El email no es valido");
                if (dto.TipoMovimientoId == 0) throw new TipoMovimientoException("El tipo de movimiento no existe");
                UsuarioDTO user = CUBuscarUsuarioPorEmail.BuscarUsuarioPorEmail(dto.EmailUsuario);
                if (CUObtenerTipoMovimientoPorId.ObtenerTipoMovimientoPorId(dto.TipoMovimientoId).TipoDeMovimiento == '=')
                    throw new TipoMovimientoException("No se manejan movimientos de tipo de traslado");
                if ((int)CUObtenerParametroPorNombre.ObtenerParametroPorNombre("Tope").Valor < dto.CantidadArticulo)
                    throw new ParametroException("Se ha pasado el tope maximo de movimiento");
                MovimientosStock movimiento = new MovimientosStock() {
                    FechaMovimiento= DateOnly.FromDateTime(dto.FechaRealizacion),
                    HoraMovimiento= TimeOnly.FromDateTime(dto.FechaRealizacion),
                    CantidadEnMovimiento = dto.CantidadArticulo,
                    ArticuloMovimientoId = dto.IdArticulo,
                    TipoDeMovimientoId = dto.TipoMovimientoId,
                    UsuarioEncargadoId = user.Id
                };
                //ENVIAR AL CASO DE USO
                CUAltaMovimientoStock.AltaMovimientoStock(movimiento);
                return Created();
            }
            catch (ParametroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArticuloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(TipoMovimientoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(MovimientoStockException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return new ContentResult { Content="Hubo un error",StatusCode = 500};
            }
        }

    }
}
