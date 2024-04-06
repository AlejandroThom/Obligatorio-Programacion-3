using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects.ArticulosVO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    
    public class Articulo : IValidable
    {
        public int Id { get; set; }

        public NombreVO NombreArticulo { get; set; }
        /// <summary>
        /// La descripcion debe tener un minimo de 5 caracteres
        /// </summary>
        public DescripcionVO DescripcionArticulo { get; set;}
        /// <summary>
        /// (es el que puede utilizarse como código de barras, tiene 13 dígitos
        /// significativos; por el momento no se solicita que el código siga un formato de los estandarizados)
        /// </summary>
        public decimal PrecioPublico { get; set; }
        public CodigoVO CodigoArticulo { get; set; }
        public int Stock { get; set; }

        public Articulo() { }

        /// <summary>
        /// Verifica que el articulo sea valido.
        /// </summary>
        public void Validar()
        {
            ValidarPrecioPublico();
            ValidarStock();
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
