using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Projects.Domain.Models
{
    public class Proyecto
    {
        public int id { get; set; }
             
        public string url_to_image { get; set; }
             
        public string nombre { get; set; }

        //Relationships

        public int usuarios_id { get; set; }

        [JsonIgnore]
        public Usuario usuario { get; set; }

        public Bono bono { get; set; }

        public DataFrances data_frances { get; set; }

        public IList<Crud> cruds { get; set; }

    }
}