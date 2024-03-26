using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario.Interfaces
{
    public interface ICUBuscarUsuario
    {
        Usuario BuscarUsuarioPorId(int id);

    }
}
