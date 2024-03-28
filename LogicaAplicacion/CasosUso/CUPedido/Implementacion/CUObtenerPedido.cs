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
    public class CUObtenerPedidos : ICUObtenerPedidos
    {
        public IRepositorio<Pedido> RepoPedidos { get; set; }

        public CUObtenerPedidos(IRepositorio<Pedido> repoPedidos)
        {
            RepoPedidos = repoPedidos;
        }
        public IEnumerable<Pedido> ObtenerPedidos()
        {
            return RepoPedidos.FindAll();
        }

        public async Task<IEnumerable<Pedido>> ObtenerPedidosAsync()
        {
            return await RepoPedidos.FindAllAsync();
        }
    }
}
