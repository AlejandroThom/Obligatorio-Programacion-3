using DTO;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiObligatorioP3.Token;

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ICUInicioDeSesion CUInicioDeSesion { get; set; }

        public UsuarioController(ICUInicioDeSesion cUInicioDeSesion)
        {
            CUInicioDeSesion = cUInicioDeSesion;
        }

        /// <summary>
        /// Realiza el Login de un usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Un objeto con el rol, token y el email</returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] UsuarioLoginDTO dto)
        {
            try
            {
                if (dto == null) throw new UsuarioException("Datos incorrectos");
                UsuarioLoginRetornoDTO retorno = CUInicioDeSesion.BuscarUsuarioPorEmailYPassword(dto.Email, Utilities.Encriptar(dto.Password));
                retorno.Token = ManejadorToken.CrearToken(retorno);
                return Ok(retorno);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return new ContentResult { Content = "Error inesperado", StatusCode = 500 };
            }
        }
    }
}
