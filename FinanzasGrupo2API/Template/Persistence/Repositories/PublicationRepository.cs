using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Publications.Domain.Models;
using FinanzasGrupo2API.Publications.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Publications.Persistence.Repositories
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.Include(p=>p.Tournament).ToListAsync();
        }

        public async Task<IEnumerable<Publication>> ListByTypeAsync()
        {
            return await _context.Publications.Include(p=>p.Tournament).ToListAsync();
        }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindByIdAsync(int id)
        {
            return await _context.Publications.Include(p=>p.Tournament).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }
    }
}