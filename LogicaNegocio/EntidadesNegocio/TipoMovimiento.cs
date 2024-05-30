
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.EntidadesNegocio
{
    public class TipoMovimiento
    {
        public int Id { get; set; }
        [Required]
        public string NombreMovimiento { get; set; }

        public virtual IEnumerable<MovimientosStock> Movimientos { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}