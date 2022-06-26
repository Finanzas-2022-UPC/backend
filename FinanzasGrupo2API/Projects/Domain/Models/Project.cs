using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Projects.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
             
        public string UrlToImage { get; set; }
             
        public string Name { get; set; }

        //Relationships

        [JsonIgnore]
        public User User { get; set; }

        public Bono Bono { get; set; }

        public DataFrances DataFrances { get; set; }
             
         }
}