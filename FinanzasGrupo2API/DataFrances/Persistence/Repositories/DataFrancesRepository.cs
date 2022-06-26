using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.DataFrancess.Persistence.Repositories
{
    public class DataFrancesRepository : BaseRepository, IDataFrancesRepository
    {
        public DataFrancesRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<DataFrances>> ListAsync()
        {
            return await _context.DataFrances.Include(b=>b.Project).ToListAsync();
        }
       
        public async Task AddAsync(DataFrances dataFrances)
        {
            await _context.DataFrances.AddAsync(dataFrances);
        }

        public async Task<DataFrances> FindByIdAsync(int id)
        {
            return await _context.DataFrances.Include(b=>b.Project).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public void Update(DataFrances dataFrances)
        {
            _context.DataFrances.Update(dataFrances);
        }

        public void Remove(DataFrances dataFrances)
        {
            _context.DataFrances.Remove(dataFrances);
        }
    }
}