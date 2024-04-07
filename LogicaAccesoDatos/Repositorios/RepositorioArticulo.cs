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
    public class RepositorioArticulo : IRepositorio<Articulo>
    {
        private readonly PapeleriaContext _context;

        public RepositorioArticulo (PapeleriaContext context)
        {
            _context = context;
        }

        public void Add(Articulo item)
        {
            item.Validar();
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Articulo art = FindById(id);
            if (art != null)
            {
                _context.Articulos.Remove(art);
                _context.SaveChanges();
            }
            else{
                throw new Exception($"El articulo con el Id '{id}' no existe.");
            }
        }
        public IEnumerable<Articulo> FindAll()
        {
            return _context.Articulos;
        }

        public Articulo FindById(int id)
        {
            return _context.Articulos.Find(id);
        }

        public void Update(Articulo item)
        {
            Articulo art = FindById(item.Id);
            if (art != null)
            {
                art.Stock = item.Stock;
                art.PrecioPublico = item.PrecioPublico;
                art.DescripcionArticulo = item.DescripcionArticulo;
                art.NombreArticulo = item.NombreArticulo;
                art.CodigoArticulo = item.CodigoArticulo;
                _context.Articulos.Update(art);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"El articulo con el Id '{item.Id}' no existe.");
            }
        }
    }
}
