using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Services.Communication;
using FinanzasGrupo2API.Movimientos.Resources;

namespace FinanzasGrupo2API.Movimientos.Domain.Services
{
    public interface ITipoMovimientoService
    {
        Task<IEnumerable<TipoMovimiento>> ListAsync();
        
        Task<TipoMovimiento> GetById(int id);

        Task<TipoMovimientoResponse> SaveAsync(SaveTipoMovimientoResource tipoMovimiento);

        Task<TipoMovimientoResponse> UpdateAsync(int id, TipoMovimiento tipoMovimiento);

        Task<TipoMovimientoResponse> DeleteAsync(int id);
    }
}