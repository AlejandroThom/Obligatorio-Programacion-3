using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUPedido.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUPedido.Implementacion
{
    public class CUAnularPedido : ICUAnularPedido
    {
        public IRepositorioPedido Repo { get; set; }
        public CUAnularPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public void AnularPedido(int id)
        {
            Repo.AnularPedido(id);
        }
    }
}
