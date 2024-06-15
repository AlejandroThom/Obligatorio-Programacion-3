using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CUUsuario.Interfaces
{
    public interface ICUBuscarUsuarioPorEmail
    {
        public UsuarioDTO BuscarUsuarioPorEmail(string email);
    }
}
