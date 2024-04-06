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
    [Index(nameof(Nombre))]
    public class NombreVO
    {
        public string Nombre { get; }
        public NombreVO(string nombre)
        {
            Nombre = nombre;
            Validar();
        }

        public void Validar()
        {
            ValidarNombre();
        }
        /// <summary>
        /// Valida el nombre del usuario para que no termine o comience con un caracter que no sea alfabetico.
        /// </summary>
        /// <exception cref="UsuarioException">Lanza una excepcion si el nombre no es valido</exception>
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new UsuarioException("El nombre no puede ser vacío o nulo");
            bool noValido = Regex.IsMatch(Nombre.Substring(0, 1), @"^[^a-zA-Z]") ||
                Regex.IsMatch(Nombre.Substring(Nombre.Length - 1), @"^[^a-zA-Z]");
            if (noValido)
            {
                throw new UsuarioException("El nombre no puede empezar o terminar con un caracter no alfabetico");
            }
            
        }
    }
}
