using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUTipoMovimiento.Implementacion
{
    public class CUEliminarTipoMovimiento : ICUEliminarTipoMovimiento
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUEliminarTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }
        public void EliminarTipoMovimiento(int id)
        {
            Repo.Delete(id);
        }
    }
}
