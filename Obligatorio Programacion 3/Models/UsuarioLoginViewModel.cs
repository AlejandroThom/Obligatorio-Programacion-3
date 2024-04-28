using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioLoginViewModel
    {
        [DisplayName("Email")]
        [StringLength(50, MinimumLength = 13, ErrorMessage = "El correo  debe tener al menos 13 caracteres")]
        public String Email { get; set; }
        [DisplayName("Contraseña")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public String Password { get; set; }
    }
}
