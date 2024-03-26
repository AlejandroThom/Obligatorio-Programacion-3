using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Cliente : IValidable
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string RUT { get; set;}
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        /// <summary>
        /// La distancia, en Kilometros, de su hogar a la papeleria
        /// </summary>
        public double DistanciaPapeleria { get; set;}

        public Cliente() { }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
