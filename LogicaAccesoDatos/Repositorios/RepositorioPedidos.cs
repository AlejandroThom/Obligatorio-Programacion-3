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
    public class RepositorioPedidos : IRepositorioPedido
    {
        private readonly PapeleriaContext _context;
        public RepositorioPedidos(PapeleriaContext context)
        {
            _context = context;
        }
        public void Add(Pedido item)
        {
            item.Validar();
            foreach(Linea lin in item.Lineas)
            {
                lin.Validar();
            }
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
            return _context.Pedidos.Include(p=>p.Cliente);
        }

        public Pedido FindById(int id)
        {
            return _context.Pedidos.Include(p => p.Cliente).FirstOrDefault(p=>p.Id==id);
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
            return _context.Pedidos.Include(p => p.Cliente).Where(p => p.IsAnulado);
        }

        public IEnumerable<Pedido> FindPedidosByDate(DateTime date)
        {
            return _context.Pedidos.Include(p=>p.Cliente).Where(p => p.FechaPedido == date && p.FechaEntrega<DateTime.Now && !p.IsAnulado);
        }

        public void AnularPedido(int id)
        {
            Pedido pedido = FindById(id);
            if (pedido != null)
            {
                pedido.IsAnulado = true;
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No existe un pedido con ese id {id}");
            }
        }
    }
}
