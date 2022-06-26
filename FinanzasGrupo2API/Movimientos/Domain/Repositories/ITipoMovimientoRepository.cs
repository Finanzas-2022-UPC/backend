using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Movimientos.Domain.Models;

namespace FinanzasGrupo2API.Movimientos.Domain.Repositories
{
    public interface ITipoMovimientoRepository
    {
        Task<IEnumerable<TipoMovimiento>> ListAsync();
        
        Task AddAsync(TipoMovimiento movimiento);

        Task<TipoMovimiento> FindByIdAsync(int id);

        void Update(TipoMovimiento movimiento);
        
        void Remove(TipoMovimiento movimiento);
    }
}