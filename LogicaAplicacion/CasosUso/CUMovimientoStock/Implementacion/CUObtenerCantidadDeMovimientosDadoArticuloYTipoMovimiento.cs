using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUMovimientoStock.Implementacion
{
    public class CUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento : ICUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento
    {
        public IRepositorioMovimiento Repo { get; set; }
        public CUObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento(IRepositorioMovimiento repo)
        {
            Repo = repo;
        }
        public int ObtenerCantidadDeMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento)
        {
            return Repo.CantidadDeMovimientosDadoArticuloYTipoMovimiento(idArticulo,idTipoMovimiento);
        }
    }
}
