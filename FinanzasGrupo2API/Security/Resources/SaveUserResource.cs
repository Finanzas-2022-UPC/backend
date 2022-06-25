using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Security.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public string Username  { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string URLImage { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}