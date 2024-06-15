using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        

        public ICUObtenerParametroPorNombre CUObtenerParametroPorNombre { get; set; }

        public ParametrosController(ICUObtenerParametroPorNombre cUObtenerParametroPorNombre)
        {
            CUObtenerParametroPorNombre = cUObtenerParametroPorNombre;
        }


        /// <summary>
        /// Recupera los datos de un tipo de parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Retorno un DTO con el nombre y el valor del parametro</returns>
        // GET api/<ParametrosController>/5
        [HttpGet("{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre)) return BadRequest();
                return Ok(CUObtenerParametroPorNombre.ObtenerParametroPorNombre(nombre));
            }
            catch (Exception ex)
            {
                return new ContentResult { StatusCode = 500, Content = "Hubo un error" };
            }
        }

    }
}
