using LogicaNegocio.ValueObjects.UsuarioVO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio_Programacion_3.Models
{
    public class UsuarioViewModel
    {
        public EmailVO EmailVO { get; set; }
        public NombreVO NombreVO { get; set; }
        public ApellidoVO ApellidoVO { get; set; }
        public string Password { get; set; }
        public UsuarioViewModel() { }

    }
}
