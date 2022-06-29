using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Movimientos.Domain.Models
{
    public class Movimiento
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string monto { get; set; }
        public float incremento { get; set; }
        public string mes_aplicable { get; set; }

        //Relationships

        public int tipo_movimientos_id { get; set; }

        public int crud_id { get; set; }

        [JsonIgnore]
        public TipoMovimiento tipo_movimiento { get; set; }
        [JsonIgnore]
        public Crud crud { get; set; }
    }
}