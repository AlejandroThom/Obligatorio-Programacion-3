using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioLoginRetornoDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Rol {  get; set; }
    }
}
