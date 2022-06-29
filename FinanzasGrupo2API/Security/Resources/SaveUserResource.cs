using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Security.Resources
{
    public class SaveUsuarioResource
    {
        [Required]
        [MaxLength(50)]
        public string nombre  { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required]
        [MinLength(6)]
        public string password { get; set; }
    }
}