﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioListadoDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public string Rol {  get; set; }
    }
}
