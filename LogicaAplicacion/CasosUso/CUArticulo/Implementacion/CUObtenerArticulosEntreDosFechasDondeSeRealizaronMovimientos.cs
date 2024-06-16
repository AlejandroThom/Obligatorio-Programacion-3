using DTO;
using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUArticulo.Interfaces;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUArticulo.Implementacion
{
    public class CUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos : ICUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos
    {
        public IRepositorioArticulo Repo { get; set; }
        public CUObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public IEnumerable<ArticuloListadoDTO> ObtenerArticulosEntreDosFechasDondeSeRealizaronMovimientos(DateTime inicio, DateTime fin, int pagina)
        {
            return ArticuloMappers.ToListaDto(Repo.ObtenerArticulosPorMovimientosDeStockEntreDosFechas(inicio, fin, pagina));
        }
    }
}
