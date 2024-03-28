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
    [Owned]
    [Index([nameof(Calle),nameof(Numero), nameof(Ciudad)], IsUnique = true)]
    public class Direccion
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        public Direccion() { }
    }
}
