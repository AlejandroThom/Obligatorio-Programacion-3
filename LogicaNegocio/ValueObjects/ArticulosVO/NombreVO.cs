using LogicaNegocio.Excepciones.Articulo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.ArticulosVO
{
    [Owned]
    [Index(nameof(Nombre), IsUnique = true)]
    public class NombreVO
    {

        public string Nombre { get; }
        public NombreVO(string nombre) { 
            Nombre = nombre;
            Validar();
        }

        private void Validar()
        {
            ValidarNombre();
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

    }
}
