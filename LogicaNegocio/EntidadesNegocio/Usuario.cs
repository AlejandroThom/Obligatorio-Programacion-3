using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.Interfaces;
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
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        public string PasswordEncriptada { get; set; }

        public Usuario() {  }
        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarPassword();
        }

        /// <summary>
        /// Valida el nombre del usuario para que no termine o comience con un caracter que no sea alfabetico.
        /// </summary>
        /// <exception cref="UsuarioException">Lanza una excepcion si el nombre no es valido</exception>
        private void ValidarNombre()
        {
            bool noValido = Regex.IsMatch(Nombre.Substring(0, 1), @"^[^a-zA-Z]") ||
                Regex.IsMatch(Nombre.Substring(Nombre.Length-1), @"^[^a-zA-Z]");
            if (noValido){
                throw new UsuarioException("El nombre no puede empezar o terminar con un caracter no alfabetico");
            }
        }
        /// <summary>
        /// Valida el apellido del usuario para que no termine o comience con un caracter que no sea alfabetico.
        /// </summary>
        /// <exception cref="UsuarioException">Lanza una excepcion si el apellido no es valido</exception>
        private void ValidarApellido()
        {
            bool noValido = Regex.IsMatch(Apellido.Substring(0, 1), @"^[^a-zA-Z]") ||
                Regex.IsMatch(Apellido.Substring(Apellido.Length - 1), @"^[^a-zA-Z]");
            if (noValido)
            {
                throw new UsuarioException("El apellido no puede empezar o terminar con un caracter no alfabetico");
            }
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
        /// <summary>
        /// Valida que el email termine en '@dominio.com' donde dominio puede ser gmail,hotmail,etc. y que tenga al menos 
        /// un caracter antes del @.
        /// </summary>
        /// <exception cref="UsuarioException">Lanza una excepcion si no cumple con las validaciones</exception>
        private void ValidarEmail() {
            Regex regex = new Regex(@"@[a-zA-Z0-9]+\.com$");
            int index = Email.IndexOf("@");
            string subS = Email.Substring(index);
            bool match = regex.IsMatch(subS);
            if (!match){
                throw new UsuarioException("El email no es valido");
            }
            if (Email.Substring(0, index-1).Length == 0)
            {
                throw new UsuarioException("El email no es valido, no tiene nombre");
            }
        }
    }
}
