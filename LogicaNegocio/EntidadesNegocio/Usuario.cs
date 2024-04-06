using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects.UsuarioVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario 
    {
        public int Id { get; set; }
        public EmailVO EmailUsuario { get; set; }
        public NombreVO NombreUsuario { get; set; }
        public ApellidoVO ApellidoUsuario { get; set; }

        public PasswordVO PasswordUsuario { get; set; }
        public string PasswordEncriptada { get; set; }

        public Usuario() {  }

    }
}
