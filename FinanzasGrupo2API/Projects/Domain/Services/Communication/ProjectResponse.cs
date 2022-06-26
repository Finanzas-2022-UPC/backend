using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Projects.Domain.Services.Communication
{
    public class ProjectResponse : BaseResponse<Project>
    {
        public ProjectResponse(string message) : base(message)
        {
        }

        public ProjectResponse(Project project) : base(project)
        {
        }
    }
}