using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Movimientos.Persistence.Repositories
{
    public class MovimientoRepository : BaseRepository, IMovimientoRepository
    {
        public MovimientoRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Movimiento>> ListAsync()
        {
            return await _context.Movimientos.Include(b => b.crud).Include(b=>b.tipo_movimiento).ToListAsync();
        }
       
        public async Task AddAsync(Movimiento movimiento)
        {
            await _context.Movimientos.AddAsync(movimiento);
        }

        public async Task<Movimiento> FindByIdAsync(int id)
        {
            return await _context.Movimientos.Include(b => b.crud).Include(b=>b.tipo_movimiento).FirstOrDefaultAsync(p=>p.id==id);
        }

        public async Task<IEnumerable<Movimiento>> ListByCrudId(int crud_id)
        {
            return await _context.Movimientos.Include(b => b.tipo_movimiento).Where(m => m.crud_id == crud_id).ToListAsync();
        }

        public void Update(Movimiento movimiento)
        {
            _context.Movimientos.Update(movimiento);
        }

        public void Remove(Movimiento movimiento)
        {
            _context.Movimientos.Remove(movimiento);
        }
    }
}