﻿using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;

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
            foreach (Linea lin in item.Lineas)
            {
                lin.Validar();
                _context.Entry(lin.Articulo).State = EntityState.Unchanged;
            }
            _context.Entry(item.Cliente).State = EntityState.Unchanged;
            _context.Pedidos.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Pedido pedido = FindById(id);
            _context.Entry(pedido.Cliente).State = EntityState.Unchanged;
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No existe un pedido con ese id");
            }
        }

        public IEnumerable<Pedido> FindAll()
        {
            return _context.Pedidos.Include(p => p.Cliente).ToList();
        }

        public Pedido FindById(int id)
        {
            return _context.Pedidos.Include(p => p.Cliente).Include(p => p.Lineas)
                .ThenInclude(linea => linea.Articulo).FirstOrDefault(p => p.Id == id);
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

        public void AgregarLinea(int idPedido, Linea item)
        {
            item.Validar();
            Pedido pedido = FindById(idPedido);
            if (pedido != null)
            {
                foreach (Linea lin in pedido.Lineas)
                {
                    _context.Entry(lin.Articulo).State = EntityState.Unchanged;
                }
                _context.Entry(item.Articulo).State = EntityState.Unchanged;
                pedido.IsLineaExistente(item);
                pedido.AgregarLinea(_context.Parametros.FirstOrDefault(p => p.Nombre == "IVA").Valor, item);
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
            IEnumerable<Pedido> dev = _context.Pedidos.Include(p => p.Cliente).Where(p => p.IsAnulado).OrderByDescending(p => p.FechaEntrega).ToList();

            return dev;
        }

        public IEnumerable<Pedido> FindPedidosByDate(DateTime date)
        {
            return _context.Pedidos.Include(p => p.Cliente)
                .Where(p => p.FechaPedido.Date == date.Date && p.FechaEntrega > DateTime.Now && !p.IsAnulado).ToList();
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
