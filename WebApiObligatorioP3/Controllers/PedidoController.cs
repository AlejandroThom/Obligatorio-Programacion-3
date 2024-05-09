using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
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


        [HttpGet]
        [Route("Anulados")]
        public ActionResult GetPedidosAnuladosOrdenados()
        {
            try
            {
                return Ok(CUObtenerPedidosAnulados.ObtenerPedidosAnulados());

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
