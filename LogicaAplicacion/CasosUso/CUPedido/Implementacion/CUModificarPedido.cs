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
    public class CUModificarPedido : ICUModificarPedido
    {
        public IRepositorio<Pedido> RepoPedidos { get; set; }

        public CUModificarPedido(IRepositorio<Pedido> repoPedidos)
        {
            RepoPedidos = repoPedidos;
        }
        public void ModificarPedido(Pedido pedido )
        {
            RepoPedidos.Update(pedido);
        }
    }
}