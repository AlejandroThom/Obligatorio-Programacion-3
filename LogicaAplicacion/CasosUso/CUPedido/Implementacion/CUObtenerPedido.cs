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
        public IRepositorioPedido RepoPedidos { get; set; }

        public CUObtenerPedidos(IRepositorioPedido repoPedidos)
        {
            RepoPedidos = repoPedidos;
        }
        public IEnumerable<Pedido> ObtenerPedidos()
        {
            return RepoPedidos.FindAll();
        }
    }
}
