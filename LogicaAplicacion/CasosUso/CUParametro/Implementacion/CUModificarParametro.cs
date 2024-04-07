using LogicaAccesoDatos.InterfacesRepositorios;
using LogicaAplicacion.CasosUso.CUParametro.Interfaces;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUParametro.Implementacion
{
    public class CUModificarParametro : ICUModificarParametro
    {
        public IRepositorioParametro Repositorio {  get; set; }

        public CUModificarParametro(IRepositorioParametro repositorio)
        {
            Repositorio = repositorio;
        }

        public void ModificarParametro(Parametro parameter)
        {
            Repositorio.Update(parameter);
        }
    }
}
