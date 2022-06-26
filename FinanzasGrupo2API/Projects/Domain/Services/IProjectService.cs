using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Services.Communication;
using FinanzasGrupo2API.Projects.Resources;

namespace FinanzasGrupo2API.Projects.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync(int ? userId);
        
        Task<Project> GetById(int id);

        Task<ProjectResponse> SaveAsync(SaveProjectResource project);

        Task<ProjectResponse> UpdateAsync(int id, Project project);

        Task<ProjectResponse> DeleteAsync(int id);
    }
}