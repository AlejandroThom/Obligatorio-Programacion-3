using LogicaNegocio.Excepciones.Linea;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Linea
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int CantArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Linea() { }

        public decimal PrecioTotal()
        {
            return CantArticulo*PrecioUnitario;
        }

        /// <summary>
        /// Valida que las propiedades de la clase Linea 
        /// </summary>
        public void Validar()
        {
            ValidarCantArticulo();
            ValidarPrecioUnitario();
        }

        /// <summary>
        /// Valida que la cantidad cantidad del Articulo deba ser mayor a 0
        /// </summary>
        /// <exception cref="LineaException"></exception>
        private void ValidarCantArticulo()
        {
            if(CantArticulo < 0)
                throw new LineaException("La cantidad de del articulo debe ser mayor a 0");
        }
        /// <summary>
        /// Valida que el precio unitario deba ser mayor a 0
        /// </summary>
        /// <exception cref="LineaException"></exception>
        private void ValidarPrecioUnitario()
        {
            if (PrecioUnitario < 0)
                throw new LineaException("La Precio Unitario del articulo debe ser mayor a 0");
        }
    }
}