using LogicaNegocio.EntidadesNegocio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_Programacion_3.Models
{
    public class PedidoListadoViewModel
    {
        public int Id { get; set; }
        [DisplayName("Cliente")]
        public Cliente Cliente { get; set; }
        [Display(Name = "Fecha de envío")]
        public DateTime FechaPedido { get; set; }
        [DisplayName("Fecha de entrega")]
        public DateTime FechaEntrega { get; set; }
        [Display(Name = "Precio del pedido")]
        public decimal Precio { get; set; }
        public bool IsAnulado { get; set; }


        public bool IsEntregado()
        {
            return FechaEntrega < DateTime.Now;
        }

    }
}
