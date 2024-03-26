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
    public class RepositorioClientes : IRepositorio<Cliente>
    {
        private readonly PapeleriaContext _context;

        public RepositorioClientes(PapeleriaContext context)
        {
            _context = context;
        }


        public void Add(Cliente item)
        {
            item.Validar();
            _context.Clientes.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Cliente cli = FindById(id);
            if (cli != null)
            {
                _context.Clientes.Remove(cli);
                _context.SaveChanges();
            }
            else{
                throw new Exception($"No existe ese cliente con ese Id -> {id}");
            }
        }

        public async Task<IEnumerable<Cliente>> FindAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente FindById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Update(Cliente item)
        {
            Cliente cli = FindById(item.Id);
            if (cli != null)
            {
                cli.Calle = item.Calle;
                cli.Numero = item.Numero;
                cli.Ciudad = item.Ciudad;
                cli.DistanciaPapeleria = item.DistanciaPapeleria;
                _context.Clientes.Update(cli);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No existe ese cliente con ese Id -> {item.Id}");
            }
        }
    }
}
