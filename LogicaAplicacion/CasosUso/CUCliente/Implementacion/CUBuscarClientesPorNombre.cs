using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUCliente.Implementacion
{
    public class CUBuscarClientesPorNombre : ICUBuscarClientesPorNombre
    {
        public IRepositorioCliente Repositorio {  get; set; }

        public CUBuscarClientesPorNombre(IRepositorioCliente rep)
        {
            Repositorio = rep;
        }
        public IEnumerable<Cliente> FindClientesPorNombre(string nombre, string apellido)
        {
            return Repositorio.FindClientsByName(nombre, apellido);
        }
    }
}
