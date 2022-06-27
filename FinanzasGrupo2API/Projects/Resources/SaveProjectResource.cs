using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Projects.Resources
{
    public class SaveProyectoResource
    {
        [Required] [MaxLength(50)] public string nombre { get; set; }
             
        public string url_to_image { get; set; }
                          
        [Required] public int usuarios_id { get; set; }

    }
}

