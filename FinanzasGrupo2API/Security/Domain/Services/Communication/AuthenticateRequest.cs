using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Security.Domain.Services.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}