using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Security.Domain.Models
{
    public class Usuario
    {
      public int id { get; set; }
      public string nombre { get; set; }
      public string email { get; set; }

      [JsonIgnore]
      public string password_hash { get; set; }

      public IList<Proyecto> projects { get; set; }
   
    }
}