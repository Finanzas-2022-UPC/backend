using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Security.Domain.Services.Communication
{
    public class UsuarioResponse : BaseResponse<Usuario>
    {
        public UsuarioResponse(string message) : base(message)
        {
        }

        public UsuarioResponse(Usuario user) : base(user)
        {
        }
    }
}