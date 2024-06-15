using DTO;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ParametroMappers
    {
        public static ParametroDTO ToDTO(Parametro para)
        {
            if (para == null) throw new Exception("Hubo un error");
            return new ParametroDTO() { Nombre = para.Nombre,Valor=(int)para.Valor};
        }
    }
}
