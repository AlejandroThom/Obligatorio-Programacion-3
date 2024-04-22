using LogicaNegocio.ValueObjects.UsuarioVO;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioEditViewModel
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Password { get; set; }
    }
}
