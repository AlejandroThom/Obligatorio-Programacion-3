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
    public class RepositorioPedidos : IRepositorioPedido<Pedido>
    {
        private readonly PapeleriaContext _context;
        public RepositorioPedidos(PapeleriaContext context)
        {
            _context = context;
        }
        public void Add(Pedido item)
        {
            item.Validar();
            _context.Pedidos.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Pedido pedido = FindById(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
            else{
                throw new Exception("No existe un pedido con ese id");
            }
        }

        public IEnumerable<Pedido> FindAll()
        {
            return _context.Pedidos.ToList();
        }

        public Pedido FindById(int id)
        {
            return _context.Pedidos.Find(id);
        }

        public void Update(Pedido item)
        {
            Pedido pedido = FindById(item.Id);
            if (pedido != null)
            {
                pedido.Lineas = item.Lineas;
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No existe un pedido con ese id");
            }
        }

        public IEnumerable<Pedido> FindPedidosAnulados()
        {
            return _context.Pedidos.Where(p => p.IsAnulado).ToList();
        }

        public IEnumerable<Pedido> FindPedidosByDate(DateTime date)
        {
            return _context.Pedidos.Where(p => p.FechaPedido == date).ToList();
        }
    }
}
