using LogicaNegocio.Excepciones.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.ValueObjects.UsuarioVO
{
    [Owned]
    [Index(nameof(Email),IsUnique =true)]
    public class EmailVO
    {
        public string Email { get; }

        public EmailVO(string email) {
        
            this.Email = email;
            Validar();
        }

        public void Validar()
        {
            ValidarEmail();
        }

        /// <summary>
        /// Valida que el email termine en '@dominio.com' donde dominio puede ser gmail,hotmail,etc. y que tenga al menos 
        /// un caracter antes del @.
        /// </summary>
        /// <exception cref="UsuarioException">Lanza una excepcion si no cumple con las validaciones</exception>
        private void ValidarEmail()
        {
            Regex regex = new Regex(@"@[a-zA-Z0-9]+\.com$");
            int index = Email.IndexOf("@");
            string subS = Email.Substring(index);
            bool match = regex.IsMatch(subS);
            if (!match)
            {
                throw new UsuarioException("El email no es valido");
            }
            if (Email.Substring(0, index - 1).Length == 0)
            {
                throw new UsuarioException("El email no es valido, no tiene nombre");
            }
            if(Regex.IsMatch(Email.Substring(0, 1), @"^[^a-zA-Z]"))
            {
                throw new UsuarioException("El email no puede comenzar un un caracter no alfabetico");
            }
        }
    }
}
