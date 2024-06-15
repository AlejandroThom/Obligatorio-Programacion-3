using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioMovimiento : IRepositorioMovimiento
    {
        private readonly PapeleriaContext _context;

        public RepositorioMovimiento(PapeleriaContext context)
        {
            _context = context;
        }
        public void Add(MovimientosStock item)
        {
            item.Validar();
            _context.Movimientos.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientosStock> FindAll()
        {
            throw new NotImplementedException();
        }

        public MovimientosStock FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MovimientosStock item)
        {
            throw new NotImplementedException();
        }
    }
}
