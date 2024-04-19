using LogicaNegocio.Excepciones.Pedido;

namespace LogicaNegocio.EntidadesNegocio
{
    public class PedidoExpress : Pedido
    {
        public override void ValidarFechaEntrega()
        {
            base.ValidarFechaEntrega();
            if ((FechaEntrega - FechaPedido).TotalDays > 5)
            {
                throw new PedidoException("El pedido express no puede superar los 5 días de diferencia");
            }
        }
        public override void AsignarPrecioFinal(decimal iva)
        {
            base.AsignarPrecioFinal(iva);
            if (FechaEntrega.Date == FechaPedido.Date)
                PrecioPedidoFinal += PrecioPedidoFinal * (decimal)0.15;
            else
                PrecioPedidoFinal += PrecioPedidoFinal * (decimal)0.10;
            PrecioPedidoFinal += (PrecioPedidoFinal * (iva / 100));
        }

        public override void AgregarLinea(decimal iva, Linea linea)
        {
            Lineas.Add(linea);
            decimal precioLineaFinal = linea.PrecioTotal();
            if (FechaEntrega.Date == FechaPedido.Date)
                precioLineaFinal += precioLineaFinal * (decimal)0.15;
            else
                precioLineaFinal += precioLineaFinal * (decimal)0.10;
            precioLineaFinal += (precioLineaFinal * (iva / 100));
            PrecioPedidoFinal += precioLineaFinal;
        }
    }
}
