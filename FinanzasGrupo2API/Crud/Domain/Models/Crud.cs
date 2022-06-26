using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Cruds.Domain.Models
{
    public class Crud
    {
        public int Id { get; set; }

        public string Tipo { get; set; }
        public string Nombre { get; set; }

        //Relationships

        [JsonIgnore]
        public Project Project { get; set; }
        public IList<Movimiento> Movimientos { get; set; }
             
         }
}