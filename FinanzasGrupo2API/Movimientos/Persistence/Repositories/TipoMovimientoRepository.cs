using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.TipoMovimientos.Persistence.Repositories
{
    public class TipoMovimientoRepository : BaseRepository, ITipoMovimientoRepository
    {
        public TipoMovimientoRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<TipoMovimiento>> ListAsync()
        {
            return await _context.TipoMovimientos.ToListAsync();
        }
       
        public async Task AddAsync(TipoMovimiento movimiento)
        {
            await _context.TipoMovimientos.AddAsync(movimiento);
        }

        public async Task<TipoMovimiento> FindByIdAsync(int id)
        {
            return await _context.TipoMovimientos.FirstOrDefaultAsync(p=>p.Id==id);
        }

        public void Update(TipoMovimiento movimiento)
        {
            _context.TipoMovimientos.Update(movimiento);
        }

        public void Remove(TipoMovimiento movimiento)
        {
            _context.TipoMovimientos.Remove(movimiento);
        }
    }
}