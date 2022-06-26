using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Projects.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.Include(p => p.User).ToListAsync();
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Project> FindByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }
    }
}