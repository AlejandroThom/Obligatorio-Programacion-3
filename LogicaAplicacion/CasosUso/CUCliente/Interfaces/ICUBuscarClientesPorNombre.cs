using LogicaNegocio.EntidadesNegocio;

namespace LogicaAplicacion.CasosUso.CUCliente.Interfaces
{
    public interface ICUBuscarClientesPorNombre
    {
        IEnumerable<Cliente> FindClientesPorNombre(string nombre);
    }
}
