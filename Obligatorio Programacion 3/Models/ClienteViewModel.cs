using LogicaNegocio.EntidadesNegocio;

namespace Obligatorio_Programacion_3.Models
{
    public class ClienteViewModel
    {
        public string RazonSocial { get; set; }
        public string RUT { get; set; }

        public string Calle {  get; set; }
        public int Numero { get; set; }
        public string Ciudad {  get; set; }

        public double DistanciaPapeleria {  get; set; }
    }
}
