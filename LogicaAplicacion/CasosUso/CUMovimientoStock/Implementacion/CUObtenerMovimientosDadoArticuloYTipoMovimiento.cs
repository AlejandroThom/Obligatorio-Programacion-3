using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUMovimientoStock.Interfaces;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUMovimientoStock.Implementacion
{
    public class CUObtenerMovimientosDadoArticuloYTipoMovimiento : ICUObtenerMovimientosDadoArticuloYTipoMovimiento
    {
        public IRepositorioMovimiento Repo { get; set; }
        public CUObtenerMovimientosDadoArticuloYTipoMovimiento(IRepositorioMovimiento repo)
        {
            Repo = repo;
        }

        public IEnumerable<MovimientoDTO> ObtenerMovimientosDadoArticuloYTipoMovimiento(int idArticulo, int idTipoMovimiento, int pagina)
        {
            return MovimientoMappers.ToListadoDTOs(Repo.ObtenerMovimientosDadoArticuloYTipoMovimiento(idArticulo, idTipoMovimiento, pagina));
        }
    }
}
