using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Cruds.Domain.Models
{
    public class Crud
    {
        public int id { get; set; }

        public string tipo { get; set; }
        public string nombre { get; set; }

        [JsonIgnore]
        public Proyecto proyecto { get; set; }

        public int proyectos_id { get; set; }

        public IList<Movimiento> movimientos { get; set; }
             
         }
}