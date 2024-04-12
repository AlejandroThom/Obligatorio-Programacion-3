using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioCliente :IRepositorio<Cliente>
    {
        IEnumerable<Cliente> FindAll();
        public IEnumerable<Cliente> FindClientsByName(string name,string lastName);
        public IEnumerable<Cliente> FindClientsByAmountSpent(decimal amountSpent);
    }
}
