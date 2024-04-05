using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioPedido<Pedido>:IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> FindPedidosAnulados();
        IEnumerable<Pedido> FindPedidosByDate(DateTime date);
    }
}
