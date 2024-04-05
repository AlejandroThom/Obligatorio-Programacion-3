using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUObtenerPedidosAnulados : ICUObtenerPedidosAnulados
    {
        public IRepositorioPedido<Pedido> Repositorio {get;set; }

        public CUObtenerPedidosAnulados(IRepositorioPedido<Pedido> repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<Pedido> ObtenerPedidosAnulados()
        {
            return Repositorio.FindPedidosAnulados();
        }
    }
}
