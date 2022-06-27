using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Projects.Persistence.Repositories
{
    public class ProyectoRepository : BaseRepository, IProyectoRepository
    {
        public ProyectoRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Proyecto>> ListAsync()
        {
            return await _context.Projects.Include(p => p.usuario).ToListAsync();
        }

        public async Task AddAsync(Proyecto project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Proyecto> FindByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.usuario).FirstOrDefaultAsync(p => p.id == id);
        }

        public void Update(Proyecto project)
        {
            _context.Projects.Update(project);
        }

        public void Remove(Proyecto project)
        {
            _context.Projects.Remove(project);
        }
    }
}