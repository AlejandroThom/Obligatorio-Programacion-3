using DTO;
using LogicaAplicacion.CasosUso.CURol.Interfaces;
using LogicaAplicacion.CasosUso.CUUsuario.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.Utils;
using Mapper;
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
        public ICUAltaUsuario CUAltaUsuario { get; set; }
        public ICUBuscarRolPorNombre CUBuscarRolPorNombre { get; set; }

        public UsuarioController(ICUInicioDeSesion cUInicioDeSesion, ICUAltaUsuario cUAltaUsuario,ICUBuscarRolPorNombre cUBuscarRolPorNombre)
        {
            CUInicioDeSesion = cUInicioDeSesion;
            CUAltaUsuario = cUAltaUsuario;
            CUBuscarRolPorNombre = cUBuscarRolPorNombre;
        }

        /// <summary>
        /// Permite registrar un nuevo Usuario, por defecto un encargado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Registro([FromBody] DTOUsuarioRegistro dto)
        {
            try
            {
                Usuario user = UsuarioMappers.ToUsuarioFromDTOUsuarioRegistro(dto);
                user.PasswordEncriptada = Utilities.Encriptar(dto.Password);
                user.RolId = CUBuscarRolPorNombre.BuscarRolPorNombre(dto.GetNombreRol()).Id;
                CUAltaUsuario.AltaUsuario(user);
                return Created();
            }
            catch(UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            { 
                return new ContentResult { Content = "Error inesperado", StatusCode = 500 };
            }
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
