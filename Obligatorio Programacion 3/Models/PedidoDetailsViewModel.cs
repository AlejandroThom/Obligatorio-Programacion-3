using LogicaNegocio.EntidadesNegocio;
using System.ComponentModel;

namespace Obligatorio_Programacion_3.Models
{
    public class PedidoDetailsViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        [DisplayName("Fecha de envío")]
        public DateTime FechaPedido { get; set; }
        [DisplayName("Fecha de entrega")]
        public DateTime FechaEntrega { get; set; }
        public bool IsAnulado { get; set; }
        public List<LineaListadoViewModel> Lineas { get; set; }
        [DisplayName("Precio Final")]
        public decimal PrecioPedidoFinal { get; set; }
    }
}
