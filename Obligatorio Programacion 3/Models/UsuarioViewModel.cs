using LogicaNegocio.ValueObjects.UsuarioVO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioViewModel
    {
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        public UsuarioViewModel() { }

    }
}
