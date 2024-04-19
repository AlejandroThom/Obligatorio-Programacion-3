using LogicaNegocio.Excepciones.Pedido;

namespace LogicaNegocio.EntidadesNegocio
{
    public class PedidoComun : Pedido
    {
        public override void ValidarFechaEntrega()
        {
            base.ValidarFechaEntrega();
            if ((FechaEntrega - FechaPedido).TotalDays <= 7)
            {
                throw new PedidoException("Los pedidos común no pueden tener una fecha prometida menor a una semana");
            }
        }

        public override void AsignarPrecioFinal(decimal iva)
        {
            base.AsignarPrecioFinal(iva);
            if (Cliente.DistanciaPapeleria > 100)
                PrecioPedidoFinal += PrecioPedidoFinal * (decimal)0.05;

            PrecioPedidoFinal += (PrecioPedidoFinal * (iva / 100));
        }

        public override void AgregarLinea(decimal iva, Linea linea)
        {
            Lineas.Add(linea);
            decimal precioLineaFinal = linea.PrecioTotal();
            if (Cliente.DistanciaPapeleria > 100)
                precioLineaFinal += precioLineaFinal * (decimal)0.05;
            precioLineaFinal += (precioLineaFinal * (iva / 100));
            PrecioPedidoFinal += precioLineaFinal;
        }
    }
}
