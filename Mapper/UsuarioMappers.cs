using DTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class UsuarioMappers
    {
        public static UsuarioLoginRetornoDTO ToRetornoLoginUsuarioDTO(Usuario user)
        {
            if (user == null) throw new UsuarioException("Hubo un error en los datos");
            return new UsuarioLoginRetornoDTO() { Email = user.EmailUsuario.Email, Rol = user.RolUsuario.Nombre };
        }
    }
}
