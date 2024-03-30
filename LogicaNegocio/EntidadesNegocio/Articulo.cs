using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(Nombre),IsUnique = true)]
    public class Articulo : IValidable
    {
        public int Id { get; set; }

        public string Nombre { get; set; }



        /// <summary>
        /// La descripcion debe tener un minimo de 5 caracteres
        /// </summary>
        [MinLength(5,ErrorMessage ="Debe tener al menos 5 caracteres")]
        public string Descripcion { get; set;}
        /// <summary>
        /// (es el que puede utilizarse como código de barras, tiene 13 dígitos
        /// significativos; por el momento no se solicita que el código siga un formato de los estandarizados)
        /// </summary>
        
        public decimal PrecioPublico { get; set; }

        [MinLength(13, ErrorMessage = "Debe tener al menos 13 caracteres")]
        [MaxLength(13, ErrorMessage = "Debe tener como máximo 13 caracteres")]
        public string Codigo { get; set; }
        public int Stock { get; set; }

        public Articulo() { }

        /// <summary>
        /// Verifica que el articulo sea valido.
        /// </summary>
        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarCodigo();
            ValidarPrecioPublico();
            ValidarStock();
        }

        /// <summary>
        /// Verifica que el nombre no sea nulo o vacío
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ArticuloException("El nombre del articulo no puede ser vacío o nulo");
        }
        /// <summary>
        /// Valida que la descripcion tenga al menos 5 caracteres
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarDescripcion()
        {
            if(Descripcion.Length <5)
                throw new ArticuloException("La descripcion del articulo debe tener al menos 5 caracteres.");

        }
        /// <summary>
        /// Valida que el codigo tenga los 13 caracteres correspondientes
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarCodigo()
        {
            if(Codigo.Length  != 13)
                throw new ArticuloException("El codigo del articulo debe tener solamente 13 caracteres.");

        }
        /// <summary>
        /// Valida que el precio mayor a 0
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarPrecioPublico()
        {
            if (PrecioPublico  <= 0)
                throw new ArticuloException("El precio del articulo no puede ser negativo o gratis.");

        }

        /// <summary>
        /// Valida que el Stock sea mayor a 0
        /// </summary>
        /// <exception cref="ArticuloException"></exception>
        private void ValidarStock()
        {
            if (Stock <= 0)
                throw new ArticuloException("El stock del articulo no puede ser negativo o 0.");

        }
    }
}
