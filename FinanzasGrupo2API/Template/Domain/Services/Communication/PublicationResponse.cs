using FinanzasGrupo2API.Publications.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Publications.Domain.Services.Communication
{
    public class PublicationResponse : BaseResponse<Publication>
    {
        public PublicationResponse(string message) : base(message)
        {
        }

        public PublicationResponse(Publication publication) : base(publication)
        {
        }
    }
}