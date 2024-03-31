using LogicaNegocio.EntidadesNegocio;

namespace Obligatorio_Programacion_3.Models
{
    public class ClienteViewModel
    {
        public string RazonSocial { get; set; }
        public string RUT { get; set; }

        public Direccion Direccion { get; set; }
    }
}
