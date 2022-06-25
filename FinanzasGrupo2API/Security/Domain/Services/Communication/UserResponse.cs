using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Security.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message)
        {
        }

        public UserResponse(User user) : base(user)
        {
        }
    }
}