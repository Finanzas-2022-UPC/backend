using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Movimientos.Domain.Models
{
    public class TipoMovimiento
    {
        public int id { get; set; }

        public string tipo { get; set; }

        public IList<Movimiento> movimientos { get; set; }

    }
}