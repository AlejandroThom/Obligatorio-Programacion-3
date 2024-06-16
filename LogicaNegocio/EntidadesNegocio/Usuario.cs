using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.ValueObjects.UsuarioVO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario
    {
        public int Id { get; set; }
        public EmailVO EmailUsuario { get; set; }
        public NombreVO NombreUsuario { get; set; }
        public ApellidoVO ApellidoUsuario { get; set; }

        public PasswordVO PasswordUsuario { get; set; }
        public string PasswordEncriptada { get; set; }
        [ForeignKey(nameof(RolId))]
        public int RolId { get; set; }
        public Rol RolUsuario { get; set; }

        public virtual IEnumerable<MovimientosStock> MovimientosStocks { get; set; }

        public Usuario() { }

        public Usuario(string email, string nombre, string apellido, string password, string passwordEncript)
        {
            EmailUsuario = new EmailVO(email);
            NombreUsuario = new NombreVO(nombre);
            ApellidoUsuario = new ApellidoVO(apellido);
            PasswordUsuario = new PasswordVO(password);
            PasswordEncriptada = passwordEncript;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(EmailUsuario.Email))
                throw new UsuarioException("El email no puede ser vacio");
            if (String.IsNullOrEmpty(PasswordUsuario.Password))
                throw new UsuarioException("la password no puede ser vacio");
            if (String.IsNullOrEmpty(ApellidoUsuario.Apellido))
                throw new UsuarioException("el apellido no puede ser vacio");
            if (String.IsNullOrEmpty(NombreUsuario.Nombre))
                throw new UsuarioException("El nombre no puede ser vacio");
        }


    }
}
