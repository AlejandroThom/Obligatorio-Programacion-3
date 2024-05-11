using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        public IEnumerable<Cliente> FindClientsByName(string name);
        public IEnumerable<Cliente> FindClientsByAmountSpent(decimal amountSpent);
    }
}
