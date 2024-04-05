using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Interfaces
{
    public interface ICUObtenerPedidosAnulados
    {
        IEnumerable<Pedido> ObtenerPedidosAnulados();
    }
}
