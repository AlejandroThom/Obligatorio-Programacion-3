using LogicaNegocio.EntidadesNegocio;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Obligatorio_Programacion_3.Models
{
    [DisplayName("Creacion de Pedido")]
    public class PedidoViewModel
    {
        [DisplayName("Pedido Express?")]
        public bool IsEnvioExpress {  get; set; }
        [Display(Name ="Seleccione un cliente")]
        public int ClienteId { get; set; }
        [DisplayName("Fecha de entrega")]
        [DisplayFormat(DataFormatString ="DD/MM/YYYY")]
        public DateTime FechaEntrega { get; set; }
        [Display(Name = "Seleccione un articulo")]
        public int ArticuloId { get; set; }
        [DisplayName("Cantidad del articulo")]
        [IntegerValidator(MinValue =1)]
        public int CantidadArticulo { get; set; }



    }
}
