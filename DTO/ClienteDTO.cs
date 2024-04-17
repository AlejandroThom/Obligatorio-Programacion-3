using LogicaNegocio.EntidadesNegocio;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string RUT { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public double DistanciaPapeleria { get; set; }
        public List<PedidoDTO> Pedidos { get; set; }

    }
}