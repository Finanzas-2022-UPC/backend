using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Security.Domain.Services.Communication
{
    public class RegisterRequest
    {
        [Required]
        [MaxLength(50)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string email { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }

    }
}