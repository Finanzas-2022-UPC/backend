using FinanzasGrupo2API.Movimientos.Domain.Models;

namespace FinanzasGrupo2API.Movimientos.Resources
{
    public class TìpoMovimientoResource
    {
        public int id { get; set; }

        public string tipo { get; set; }

        public IList<Movimiento> movimientos { get; set; }
    }
}