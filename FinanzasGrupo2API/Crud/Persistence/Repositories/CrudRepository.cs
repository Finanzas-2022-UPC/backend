using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Cruds.Persistence.Repositories
{
    public class CrudRepository : BaseRepository, ICrudRepository
    {
        public CrudRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Crud>> ListAsync()
        {
            return await _context.Cruds.Include(b => b.proyecto).Include(b=>b.movimientos).ToListAsync();
        }
       
        public async Task AddAsync(Crud crud)
        {
            await _context.Cruds.AddAsync(crud);
        }

        public async Task<Crud> FindByIdAsync(int id)
        {
            return await _context.Cruds.Include(b => b.proyecto).Include(b=>b.movimientos).FirstOrDefaultAsync(p=>p.id==id);
        }

        public void Update(Crud crud)
        {
            _context.Cruds.Update(crud);
        }

        public void Remove(Crud crud)
        {
            _context.Cruds.Remove(crud);
        }
    }
}