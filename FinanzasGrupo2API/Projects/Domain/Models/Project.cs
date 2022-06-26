using FinanzasGrupo2API.Security.Domain.Models;

namespace FinanzasGrupo2API.Projects.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
             
        public string UrlToImage { get; set; }
             
        public string Name { get; set; }

        //Relationships

        public User User { get; set; }

             
         }
}