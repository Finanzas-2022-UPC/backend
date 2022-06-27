using FinanzasGrupo2API.Security.Domain.Models;

namespace FinanzasGrupo2API.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(Usuario user);
        public int? ValidateToken(string token);
    }
}