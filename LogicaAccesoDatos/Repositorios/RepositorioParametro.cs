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
    public class RepositorioParametro : IRepositorioParametro
    {
        private readonly PapeleriaContext _context;

        public RepositorioParametro(PapeleriaContext context)
        {
            _context = context;
        }


        public void Update(Parametro paramater)
        {
            Parametro par = _context.Parametros.Find(paramater.Id);
            if (par == null)
            {
                throw new Exception("El parametro no existe");
            }
            par.Valor = paramater.Valor;
            par.Nombre = paramater.Nombre;
            _context.Parametros.Update(par);
            _context.SaveChanges();
        }
    }
}
