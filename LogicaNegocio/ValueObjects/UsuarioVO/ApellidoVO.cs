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
    [Index(nameof(Apellido))]
    public class ApellidoVO
    {
        public string Apellido {get;}

        public ApellidoVO(string Apellido)
        {
            this.Apellido = Apellido;
            Validar();
        }

        public void Validar()
        {
            ValidarApellido();
        }

        /// <summary>
        /// Valida el apellido del usuario para que no termine o comience con un caracter que no sea alfabetico.
        /// </summary>
        /// <exception cref="UsuarioException">Lanza una excepcion si el apellido no es valido</exception>
        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
                throw new UsuarioException("El nombre no puede ser vacío o nulo");
            bool noValido = Regex.IsMatch(Apellido.Substring(0, 1), @"^[^a-zA-Z]") ||
                Regex.IsMatch(Apellido.Substring(Apellido.Length - 1), @"^[^a-zA-Z]");
            if (noValido)
            {
                throw new UsuarioException("El apellido no puede empezar o terminar con un caracter no alfabetico");
            }
        }
    }
}
