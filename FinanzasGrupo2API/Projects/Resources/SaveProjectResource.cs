using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Projects.Resources
{
    public class SaveProjectResource
    {
        [Required] [MinLength(15)] public string Name { get; set; }
             
        public string UrlToImage { get; set; }
                          
        [Required] public int UserId { get; set; }

    }
}

