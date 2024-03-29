using LogicaNegocio.EntidadesNegocio;

namespace Obligatorio_Programacion_3.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string RUT { get; set; }

        public Direccion Direccion { get; set; }

        public ClienteViewModel() { }
    }
}
