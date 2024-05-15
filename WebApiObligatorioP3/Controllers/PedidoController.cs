using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }
    }
}
