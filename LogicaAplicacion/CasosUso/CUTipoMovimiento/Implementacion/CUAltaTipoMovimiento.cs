using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUTipoMovimiento.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUTipoMovimiento.Implementacion
{
    public class CUAltaTipoMovimiento : ICUAltaTipoMovimiento
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUAltaTipoMovimiento(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }

        public void AltaTipoMovimiento(TipoMovimiento item)
        {
            Repo.Add(item);
        }
    }
}
