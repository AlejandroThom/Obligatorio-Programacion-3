using DTO;
using LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
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
        public ICUBuscarUsuarioPorEmail CUBuscarUsuarioPorEmail { get; set; }
        public ICUAltaMovimientoStock CUAltaMovimientoStock { get; set; }
        public ICUObtenerTipoMovimientoPorId CUObtenerTipoMovimientoPorId { get; set; }
        public ICUObtenerParametroPorNombre CUObtenerParametroPorNombre { get; set; }
        public ICUObtenerResumenDeMovimientoPorAnio CUObtenerResumenDeMovimientoPorAnio { get; set; }
        public ICUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento CUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento { get; set; }
        public ICUObtenerMovimientosDadoArticuloYTipoMovimiento CUObtenerMovimientosDadoArticuloYTipoMovimiento { get; set; }

        public MovimientoController(ICUBuscarUsuarioPorEmail cuBuscarUsuarioPorEmail,
            ICUAltaMovimientoStock cUAltaMovimientoStock,
            ICUObtenerTipoMovimientoPorId cUObtenerTipoMovimientoPorId,
            ICUObtenerParametroPorNombre cUObtenerParametroPorNombre,
            ICUObtenerMovimientosDadoArticuloYTipoMovimiento cUObtenerMovimientosDadoArticuloYTipoMovimiento,
            ICUObtenerResumenDeMovimientoPorAnio cUObtenerResumenDeMovimientoPorAnio,
            ICUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento cUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento)
        {
            CUBuscarUsuarioPorEmail = cuBuscarUsuarioPorEmail;
            CUAltaMovimientoStock = cUAltaMovimientoStock;
            CUObtenerTipoMovimientoPorId = cUObtenerTipoMovimientoPorId;
            CUObtenerParametroPorNombre = cUObtenerParametroPorNombre;
            CUObtenerMovimientosDadoArticuloYTipoMovimiento = cUObtenerMovimientosDadoArticuloYTipoMovimiento;
            CUObtenerResumenDeMovimientoPorAnio = cUObtenerResumenDeMovimientoPorAnio;
            CUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento = cUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento;
        }

        /// <summary>
        /// Obtienes el resumen por año de todos los movimientos detallando:
        /// -la cantidad de cada tipo de movimiento(nombre)
        /// -la cantidad de movimientos por año
        /// </summary>
        /// <returns>Una lista con el resumen</returns>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        [HttpGet("Resumen")]
        public IActionResult ObtenerResumenDeMovimientosPorAnio()
        {
            try
            {
                return Ok(CUObtenerResumenDeMovimientoPorAnio.ObtenerResumenDeMovimientoPorAnio());
            }
            catch (Exception ex) {
                return new ContentResult { Content = "Hubo un error al obtener los datos", StatusCode = 500 };
            }
        }


        [HttpGet("Busqueda/{idArticulo:int}/{idTipoMovimiento:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerCantidadMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento)
        {
            try
            {
                if (idArticulo <= 0) return BadRequest("El articulo que selecciono no es valido");
                if (idTipoMovimiento <= 0) return BadRequest("El tipo de movimiento que selecciono no es valido");
                int value = CUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento.ObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento(idArticulo, idTipoMovimiento);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = "Hubo un error al obtener los datos", StatusCode = 500 };
            }
        }


        [HttpGet("BusquedaMovimiento/{idArticulo:int}/{idTipoMovimiento:int}/{pagina:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public IActionResult ObtenerMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento, int pagina)
        {
            try
            {
                if(pagina <= 0) return BadRequest("La pagina que selecciono no es valida");
                if (idArticulo <= 0) return BadRequest("El articulo que selecciono no es valido");
                if (idTipoMovimiento <= 0) return BadRequest("El tipo de movimiento que selecciono no es valido");
                return Ok(CUObtenerMovimientosDadoArticuloYTipoMovimiento.ObtenerMovimientosDadoArticuloYTipoMovimiento(idArticulo, idTipoMovimiento, pagina));
            }
            catch(ParamException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArticuloException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(TipoMovimientoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UsuarioException ex)
            {
                return ValidationProblem(ex.Message);
            }
            catch (Exception ex) 
            {
                return new ContentResult { Content = "Hubo un error al obtener los datos",StatusCode=500};
            }
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
