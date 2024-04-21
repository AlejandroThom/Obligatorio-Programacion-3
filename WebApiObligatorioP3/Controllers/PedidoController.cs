using DTO;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using Mapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        public ICUObtenerPedidosAnulados CUObtenerPedidosAnulados { get; set; }
        public PedidoController(ICUObtenerPedidosAnulados cuObtenerPedidosAnulados)
        {
            CUObtenerPedidosAnulados = cuObtenerPedidosAnulados;
        }

        /*
        // GET: api/<PedidoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        [HttpGet]
        [Route("PedidosAnulados")]
        public IEnumerable<PedidoListadoDTO> GetPedidosAnuladosOrdenados()
        {
            return PedidoMappers.ToListaDto(CUObtenerPedidosAnulados.ObtenerPedidosAnulados());
        }
        /*

        // POST api/<PedidoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
