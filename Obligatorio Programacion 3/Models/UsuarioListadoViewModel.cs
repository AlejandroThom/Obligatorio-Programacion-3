using LogicaNegocio.ValueObjects.UsuarioVO;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioListadoViewModel
    {
        public int Id { get; set; }
        public EmailVO Email { get; set; }
        public NombreVO Nombre { get; set; }
        public ApellidoVO Apellido { get; set; }
    }
}
