using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(RUT),IsUnique =true)]
    [Table("Clientes")]
    public class Cliente : IValidable
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }

        [MaxLength(12,ErrorMessage ="Debe tener como maximo 12 caracteres")]
        [MinLength(12,ErrorMessage = "Debe tener como minimo 12 caracteres")]
        [Required]
        public string RUT { get; set;}
        public Direccion Direccion { get; set; }

        /// <summary>
        /// La distancia, en Kilometros, de su hogar a la papeleria
        /// </summary>
        public double DistanciaPapeleria { get; set;}

        public List<Pedido> Pedidos { get; set; }


        public Cliente() { }

        /// <summary>
        /// Valida las propiedades de la clase
        /// </summary>
        public void Validar()
        {
            ValidarRazonSocial();
            ValidarRUT();
            ValidarDistaciaPapeleria();
            ValidarDireccion();
        }

        /// <summary>
        /// Valida la Direccion
        /// </summary>
        /// <exception cref="ClienteException"></exception>
        private void ValidarDireccion()
        {
            if(Direccion == null) {
                throw new ClienteException("La direccion no puede estar nula");
            }

        }

        /// <summary>
        /// Valida que la Razon Social no sea nula o vacía
        /// </summary>
        /// <exception cref="ClienteException"></exception>
        private void ValidarRazonSocial()
        {
            if (string.IsNullOrEmpty(RazonSocial))
            {
                throw new ClienteException("La razón social no puede estar vacía");
            }
        }

        /// <summary>
        /// Valida que el RUT tenga 12 caracteres numericos
        /// </summary>
        /// <exception cref="ClienteException"></exception>
        private void ValidarRUT()
        {
            if(RUT.Length != 12)
            {
                throw new ClienteException("El RUT no es valido, debe tener 12 caracteres numericos");
            }
        }

        /// <summary>
        /// Valida que la distancia entre su hogar y la papeleria sea mayor a un metro.
        /// </summary>
        /// <exception cref="ClienteException"></exception>
        private void ValidarDistaciaPapeleria()
        {
            if(DistanciaPapeleria < 0.001)
            {
                throw new ClienteException("La distancia no puede ser menor a un metro");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cl && cl.Id == this.Id;
        }
    }
}
