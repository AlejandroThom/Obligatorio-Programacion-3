using LogicaNegocio.EntidadesNegocio;

namespace LogicaAccesoDatos.InterfacesRepositorios
{
    public interface IRepositorioParametro
    {
        void Update(Parametro paramater);

        Parametro GetParametroPorNombre(string nombre);
    }
}
