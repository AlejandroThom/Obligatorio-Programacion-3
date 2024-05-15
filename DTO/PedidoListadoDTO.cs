namespace DTO
{
    public class PedidoListadoDTO
    {
        public DateTime FechaEntrega { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool IsExpress { get; set; }
    }
}
