using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Services.Communication;
using FinanzasGrupo2API.Security.Resources;

namespace FinanzasGrupo2API.Security.Domain.Services
{
    public interface IUsuarioService
    {
        
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task RegisterAsync(RegisterRequest request);
        Task<IEnumerable<Usuario>> ListAsync();
        Task<Usuario> GetByIdAsync(int userId);
        Task<Usuario> GetByUserEmailAsync(string email);
        Task<UsuarioResponse> SaveAsync(Usuario user);
        Task<UsuarioResponse> UpdateAsync(int id, SaveUsuarioResource user);
        Task<UsuarioResponse> DeleteAsync(int id);
    }
}