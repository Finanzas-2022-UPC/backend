using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Bonos.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Bonos.Persistence.Repositories
{
    public class BonoRepository : BaseRepository, IBonoRepository
    {
        public BonoRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Bono>> ListAsync()
        {
            return await _context.Bonos.Include(b=>b.proyecto).ToListAsync();
        }
       
        public async Task AddAsync(Bono bono)
        {
            await _context.Bonos.AddAsync(bono);
        }

        public async Task<Bono> FindByIdAsync(int id)
        {
            return await _context.Bonos.Include(b=>b.proyecto).FirstOrDefaultAsync(p=>p.id==id);
        }

        public void Update(Bono bono)
        {
            _context.Bonos.Update(bono);
        }

        public void Remove(Bono bono)
        {
            _context.Bonos.Remove(bono);
        }
    }
}