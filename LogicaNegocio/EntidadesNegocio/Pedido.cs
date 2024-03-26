using LogicaNegocio.Enums;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Pedido:IValidable
    {
        public int Id { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<Linea> Lineas { get; set; }

        public Pedido(){}

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
