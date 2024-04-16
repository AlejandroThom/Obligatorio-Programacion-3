using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Obligatorio_Programacion_3.Models
{
    public class ArticuloPedidoViewModel
    {
        [DisplayName("Id del Pedido")]
        public int IdPedido { get; set; }
        public bool IsEnvioExpress { get; set; }
        [Display(Name = "Cliente")]
        public ClienteListadoViewModel Cliente { get; set; }
        [DisplayName("Fecha de entrega")]
        [DisplayFormat(DataFormatString = "DD/MM/YYYY")]
        public DateTime FechaEntrega { get; set; }

        [IntegerValidator(MinValue = 1)]
        public int IdArticulo { get; set; }
        [IntegerValidator(MinValue = 1)]
        public int CantidadArticulo { get; set;}
        [DefaultValue(false)]
        public bool AgregarOtroArticulo { get; set; }
    }
}
