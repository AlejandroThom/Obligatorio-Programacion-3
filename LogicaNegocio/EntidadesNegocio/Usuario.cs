using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [DisplayName("Contraseña")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 200 caracteres")]
        public string Password { get; set; }
        public string PasswordEncriptada { get; set; }

        public Usuario() { }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
