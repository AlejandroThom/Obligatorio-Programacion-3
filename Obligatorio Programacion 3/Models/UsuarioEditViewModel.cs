using LogicaNegocio.ValueObjects.UsuarioVO;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioEditViewModel
    {
        public int Id { get; set; }
        public EmailVO Email { get; }
        public NombreVO Nombre { get; set; }
        public ApellidoVO Apellido { get; set; }
        public PasswordVO Password { get; set; }
    }
}
