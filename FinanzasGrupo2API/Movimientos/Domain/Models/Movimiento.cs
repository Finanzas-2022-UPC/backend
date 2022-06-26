using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Movimientos.Domain.Models
{
    public class Movimiento
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Monto { get; set; }
        public float Incremento { get; set; }
        public string MesAplicable { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }


        //Relationships

        [JsonIgnore]
        public Crud Crud { get; set; }
    }
}