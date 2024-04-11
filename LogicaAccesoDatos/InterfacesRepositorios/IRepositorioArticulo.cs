using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioArticulo :IRepositorio<Articulo>
    {
        bool NombreArticuloExiste (string nombreArticulo);
    }
}
