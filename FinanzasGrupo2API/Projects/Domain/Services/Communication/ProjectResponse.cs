using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Projects.Domain.Services.Communication
{
    public class ProyectoResponse : BaseResponse<Proyecto>
    {
        public ProyectoResponse(string message) : base(message)
        {
        }

        public ProyectoResponse(Proyecto project) : base(project)
        {
        }
    }
}