using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioPedido:IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> FindPedidosAnulados();
        IEnumerable<Pedido> FindPedidosByDate(DateTime date);
    }
}
