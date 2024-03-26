using LogicaNegocio.Interfaces;
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
        public string Nombre { get; set; }

        /// <summary>
        /// La descripcion debe tener un minimo de 5 caracteres
        /// </summary>
        public string Descripcion { get; set;}
        /// <summary>
        /// (es el que puede utilizarse como código de barras, tiene 13 dígitos
        /// significativos; por el momento no se solicita que el código siga un formato de los estandarizados)
        /// </summary>
        
        public decimal PrecioPublico { get; set; }
        public string Codigo { get; set; }
        public int Stock { get; set; }

        public Articulo() { }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
