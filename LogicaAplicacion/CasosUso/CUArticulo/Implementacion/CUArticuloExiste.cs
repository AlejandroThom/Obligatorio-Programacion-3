using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUArticuloExiste : ICUArticuloExiste
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUArticuloExiste(IRepositorioArticulo rep)
        {
            Repo = rep;
        }

        public bool ArticuloExiste(string nombreArticulo)
        {
            return Repo.NombreArticuloExiste(nombreArticulo);
        }
    }
}
