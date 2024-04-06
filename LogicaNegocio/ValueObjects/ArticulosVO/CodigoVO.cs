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
    [Index(nameof(Codigo))]
    public class CodigoVO
    {
        [MinLength(13, ErrorMessage = "Debe tener al menos 13 caracteres")]
        [MaxLength(13, ErrorMessage = "Debe tener como máximo 13 caracteres")]
        public string Codigo { get; }

        public CodigoVO(string codigo) {
            Codigo = codigo;
            Validar();
        }

        public void Validar()
        {
            ValidarCodigo();
        }

        /// <summary>
        /// Valida que el codigo tenga los 13 caracteres correspondientes
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarCodigo()
        {
            if (Codigo.Length != 13)
                throw new ArticuloException("El codigo del articulo debe tener solamente 13 caracteres.");

        }
    }
}
