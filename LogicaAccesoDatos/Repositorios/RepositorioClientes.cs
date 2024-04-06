using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioClientes : IRepositorioCliente
    {
        private readonly PapeleriaContext _context;

        public RepositorioClientes(PapeleriaContext context)
        {
            _context = context;
        }
        public IEnumerable<Cliente> FindClientsByName(string name, string lastName)
        {
            return _context.Clientes.Where(c=> c.RazonSocial.Contains(name) || c.RazonSocial.Contains(lastName));
        }

        public IEnumerable<Cliente> FindClientsByAmountSpent(decimal amountSpent)
        {
            List<Pedido> list = _context.Pedidos.Include(p => p.Cliente).ToList();
            IEnumerable<Cliente> clientes = new List<Cliente>();
            foreach (Pedido p in list){
                if (p.PrecioFinal(5.80) >= amountSpent && !clientes.Contains(p.Cliente)) {
                    clientes.Append(p.Cliente);
                }
            }
            return clientes;
        }
    }
}
