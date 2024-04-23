using LogicaNegocio.ValueObjects.UsuarioVO;
using System.ComponentModel;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioLoginViewModel
    {
        [DisplayName("Email")]
        public String Email { get; set; }
        [DisplayName("Contraseña")]
        public String Password { get; set; }
    }
}
