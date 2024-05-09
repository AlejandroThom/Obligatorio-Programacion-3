using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public ICUObtenerArticulosOrdenados CUObtenerArticulosOrdenados { get; set; }

        public ArticuloController(ICUObtenerArticulosOrdenados cuObtenerArtuculosOrdenados)
        {
            CUObtenerArticulosOrdenados = cuObtenerArtuculosOrdenados;
        }
        /*
        // GET: api/<ArticuloController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        [Route("OrderByName")]
        public ActionResult GetArticulosOrdenados()
        {
            try
            {
                return Ok(CUObtenerArticulosOrdenados.ObtenerArticulosOrdenados());
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        /*
        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
