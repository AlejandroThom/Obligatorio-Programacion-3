using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUCliente.Interfaces;
using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUCliente.Implementacion
{
    public class CUBuscarClientesPorNombre : ICUBuscarClientesPorNombre
    {
        public IRepositorioCliente Repositorio { get; set; }

        public CUBuscarClientesPorNombre(IRepositorioCliente rep)
        {
            Repositorio = rep;
        }
        public IEnumerable<Cliente> FindClientesPorNombre(string nombre)
        {
            return Repositorio.FindClientsByName(nombre);
        }
    }
}
