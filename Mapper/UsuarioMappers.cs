using DTO;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.ValueObjects.UsuarioVO;
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

        public static Usuario ToUsuarioFromDTOUsuarioRegistro(DTOUsuarioRegistro dto)
        {
            if (dto == null) throw new UsuarioException("Datos incompletos");
            return new Usuario()
            {
                NombreUsuario = new NombreVO(dto.Nombre),
                ApellidoUsuario = new ApellidoVO(dto.Apellido),
                EmailUsuario = new EmailVO(dto.Email),
                PasswordUsuario = new PasswordVO(dto.Password),
            };
        }

        public static UsuarioDTO ToUsuarioDTO(Usuario user)
        {
            if (user == null) throw new UsuarioException("Error en los datos");
            return new UsuarioDTO()
            {
                Id = user.Id,
                Email = user.EmailUsuario.Email,
                NombreCompleto = user.NombreUsuario.Nombre + " " + user.ApellidoUsuario.Apellido
            };
        }
    }
}
