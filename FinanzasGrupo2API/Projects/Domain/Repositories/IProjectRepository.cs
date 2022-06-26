using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Projects.Domain.Models;

namespace FinanzasGrupo2API.Projects.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        
        Task AddAsync(Project project);

        Task<Project> FindByIdAsync(int id);

        void Update(Project project);
        
        void Remove(Project project);
    }
}