using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioCliente<Cliente>
    {
        public IEnumerable<Cliente> FindClientsByName(string name,string lastName);
        public IEnumerable<Cliente> FindClientsByAmountSpent(decimal amountSpent);
    }
}
