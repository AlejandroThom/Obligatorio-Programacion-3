﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    [Index(nameof(Nombre),IsUnique =true)]
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre {  get; set; }
        public string Descripcion { get; set; }

        public virtual IEnumerable<Usuario> Usuarios { get; set; }

    }
}
