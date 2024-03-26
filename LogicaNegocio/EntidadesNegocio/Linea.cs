namespace LogicaNegocio.EntidadesNegocio
{
    public class Linea
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; } = null!;
        public int CantArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Linea() { }

        public decimal PrecioTotal()
        {
            return CantArticulo*PrecioUnitario;
        }
    }
}