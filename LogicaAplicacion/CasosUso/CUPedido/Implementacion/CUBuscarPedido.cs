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
    public class CUBuscarPedido : ICUBuscarPedido
    {
        public IRepositorio<Pedido> RepoPedidos { get; set; }

        public CUBuscarPedido(IRepositorio<Pedido> repoPedidos)
        {
            RepoPedidos = repoPedidos;
        }

        public Pedido BuscarPedidoPorId(int id)
        {
            return RepoPedidos.FindById(id);
        }
    }
}