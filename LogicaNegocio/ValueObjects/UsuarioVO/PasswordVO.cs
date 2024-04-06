using LogicaNegocio.Excepciones.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.UsuarioVO
{

    [Owned]
    [Index(nameof(Password))]
    public class PasswordVO
    {
        public string Password { get; }
        public PasswordVO(string password) {
            Password = password;
            Validar();
        }

        public void Validar()
        {
            ValidarPassword();
        }

        /// <summary>
        /// Valida que la contraseña tenga al menos 6 caracteres, 1 mayúscula,1 minúscula, 1 dígito y un carácter de puntución
        /// </summary>
        /// <exception cref="UsuarioException"></exception>
        private void ValidarPassword()
        {
            if (Password.Length < 6)
            {
                throw new UsuarioException("La contraseña debe tener al menos 6 caracteres");
            }
            if (!RequisitosPassword())
            {
                throw new UsuarioException("La contraseña debe tener al menos una mayuscula," +
                    " una minuscula, un digito y un caracter de puntuación permitidos (.,;!)");
            }
        }

        /// <summary>
        /// Verifica que los requisitos para la contraseña: 1 mayúscula,1 minúscula, 1 dígito y un carácter de puntución
        /// </summary>
        /// <returns>true si cumple, false si falta al menos un requisito</returns>
        private bool RequisitosPassword()
        {
            Regex mayuscula = new Regex("[A-Z]");
            Regex minuscula = new Regex("[a-z]");
            Regex digito = new Regex("[0-9]");
            Regex puntuacion = new Regex(@"[.;,!]");
            return mayuscula.IsMatch(Password) && minuscula.IsMatch(Password)
                && digito.IsMatch(Password) && puntuacion.IsMatch(Password);
        }

    }
}
