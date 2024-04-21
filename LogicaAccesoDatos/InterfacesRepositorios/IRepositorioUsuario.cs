using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects.UsuarioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        Usuario FindByEmailAndPass(String email, String pass); //Buscar por email y password
    }
}
