using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Services.Communication;

namespace FinanzasGrupo2API.Security.Domain.Services
{
    public interface IUserService
    {
        
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task RegisterAsync(RegisterRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int userId);
        Task<User> ListByUserUsernameAsync(int username);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}