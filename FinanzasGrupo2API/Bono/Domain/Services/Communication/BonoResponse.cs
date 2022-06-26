using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Bonos.Domain.Services.Communication
{
    public class BonoResponse : BaseResponse<Bono>
    {
        public BonoResponse(string message) : base(message)
        {
        }

        public BonoResponse(Bono bono) : base(bono)
        {
        }
    }
}