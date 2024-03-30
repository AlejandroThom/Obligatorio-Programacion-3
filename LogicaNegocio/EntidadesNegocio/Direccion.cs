using LogicaNegocio.Excepciones.Direccion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index([nameof(Calle),nameof(Numero), nameof(Ciudad)], IsUnique = true)]
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        public Direccion() { }

        /// <summary>
        /// Valida las propiedades de la clase
        /// </summary>
        public void Validar()
        {
            ValidarCalle();
            ValidarNumero();
            ValidarCiudad();
        }
        /// <summary>
        /// Valida que la Ciudad no sea null o este vacía
        /// </summary>
        /// <exception cref="DireccionException"></exception>
        private void ValidarCiudad()
        {
            if(string.IsNullOrEmpty(Ciudad))
            {
                throw new DireccionException("La Ciudad no puede ser vacía");
            }
        }
        /// <summary>
        /// Valida que el numero de la puerta de su hogar sea valido
        /// </summary>
        /// <exception cref="DireccionException"></exception>
        private void ValidarNumero()
        {
            if(Numero <= 0)
            {
                throw new DireccionException("El Número de su hogar debe ser una valida");
            }
        }
        /// <summary>
        /// Valida que la Calle no sea null o este vacía
        /// </summary>
        /// <exception cref="DireccionException"></exception>
        private void ValidarCalle()
        {
            if (string.IsNullOrEmpty(Calle))
            {
                throw new DireccionException("La Calle no puede ser vacía");
            }
        }
    }
}
