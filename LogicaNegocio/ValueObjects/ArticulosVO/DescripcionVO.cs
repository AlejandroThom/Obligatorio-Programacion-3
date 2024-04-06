using LogicaNegocio.Excepciones.Articulo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.ArticulosVO
{
    [Owned]
    [Index(nameof(Descripcion))]
    public class DescripcionVO
    {
        [MinLength(5, ErrorMessage = "Debe tener al menos 5 caracteres")]
        public string Descripcion { get; }
        public DescripcionVO(string descripcion)
        {
            Descripcion = descripcion;
            Validar();
        }

        private void Validar()
        {
            ValidarDescripcion();
        }

        /// <summary>
        /// Valida que la descripcion tenga al menos 5 caracteres
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarDescripcion()
        {
            if (Descripcion.Length < 5)
                throw new ArticuloException("La descripcion del articulo debe tener al menos 5 caracteres.");

        }
    }
}
