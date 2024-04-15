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

        public IEnumerable<Cliente> FindAll()
        {
            return _context.Clientes;
        }

        public IEnumerable<Cliente> FindClientsByName(string name, string lastName)
        {
            return _context.Clientes.Where(c=> c.RazonSocial.Contains(name) || c.RazonSocial.Contains(lastName));
        }

        public IEnumerable<Cliente> FindClientsByAmountSpent(decimal amountSpent)
        {
            var list = _context.Pedidos
                .Where(pedido => !pedido.IsAnulado) // Solo consideramos los pedidos no anulados
                .Join(_context.Clientes, // Join con la tabla de Clientes
                    pedido => pedido.Cliente.Id, // Selector de clave externa
                    cliente => cliente.Id, // Selector de clave principal
                    (pedido, cliente) => new { Pedido = pedido, Cliente = cliente }) // Proyección de resultados
                .GroupBy(
                    result => new { result.Cliente.Id, result.Cliente.RazonSocial }, // Agrupar por Id y Nombre del Cliente
                    result => result.Pedido.PrecioPedidoFinal, // Selector de valor para la suma
                    (key, values) => new // Proyectar el resultado final
                    {
                        ClienteId = key.Id,
                        NombreCliente = key.RazonSocial,
                        TotalGastado = values.Sum()
                    }).ToList();

            List<Cliente> clientes = new List<Cliente>();
            foreach (var p in list){
                if(p.TotalGastado >= amountSpent)
                {
                    Cliente cliente = _context.Clientes.Find(p.ClienteId);
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public void Add(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente FindById(int id)
        {
            return _context.Clientes.Find(id);
        }
    }
}
