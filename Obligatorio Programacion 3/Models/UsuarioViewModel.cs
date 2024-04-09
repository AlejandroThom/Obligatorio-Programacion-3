using LogicaNegocio.ValueObjects.UsuarioVO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioViewModel
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public UsuarioViewModel() { }

    }
}
