using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Domain.Models;

namespace FinanzasGrupo2API.Projects.Resources
{
    public class ProjectResource
    {
        public int Id { get; set; }
             
        public string Name { get; set; }
             
        public string UrlToImage { get; set; }
             
             
        //Relationships
        public int UserId { get; set; }
        public Bono Bono { get; set; }
        public DataFrances DataFrances { get; set; }

    }
}