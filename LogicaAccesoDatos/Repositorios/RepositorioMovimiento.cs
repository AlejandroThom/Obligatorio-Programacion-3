using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.EntityFrameworkCore;
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

        public int CantidadDeMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento)
        {
            return _context.Movimientos.Where(m => m.ArticuloMovimientoId == idArticulo)
                .Where(m => m.TipoDeMovimientoId == idTipoMovimiento).ToList().Count();
        }

        public IEnumerable<MovimientosStock> ObtenerMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento, int pagina)
        {
            List<MovimientosStock> movi = _context.Movimientos.Where(m => m.ArticuloMovimientoId == idArticulo)
                .Where(m => m.TipoDeMovimientoId == idTipoMovimiento)
                .Include(m => m.ArticuloMovimiento)
                .Include(m => m.TipoDeMovimiento)
                .Include(m => m.UsuarioEncargado).ThenInclude(u => u.RolUsuario)
                .Skip((pagina - 1) * 5)
                .Take(pagina * 5)
                .OrderByDescending(m=>m.FechaMovimiento)
                .OrderBy(m=>m.CantidadEnMovimiento)
                .ToList();

            return movi;
        }

        public IEnumerable<object> ResumenDeMovimientosPorAnio()
        {
              var result =  _context.Movimientos.GroupBy(m=>m.FechaMovimiento.Year)
                .Select(g=> new {
                    Anio = g.Key,
                    TipoMovimiento = g.GroupBy(m=>m.TipoDeMovimiento.NombreMovimiento)
                    .Select(tm => new
                    {
                        NombreTipo = tm.Key,
                        Cantidad = tm.Count()
                    }), 
                    TotalMovimientos = g.Count()
                }).OrderBy(g=>g.Anio).ToList();
            return result;
        }

        public void Update(MovimientosStock item)
        {
            throw new NotImplementedException();
        }
    }
}
