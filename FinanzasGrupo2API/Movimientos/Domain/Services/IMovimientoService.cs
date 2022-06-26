using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Services.Communication;
using FinanzasGrupo2API.Movimientos.Resources;

namespace FinanzasGrupo2API.Movimientos.Domain.Services
{
    public interface IMovimientoService
    {
        Task<IEnumerable<Movimiento>> ListAsync();
        
        Task<Movimiento> GetById(int id);

        Task<MovimientoResponse> SaveAsync(SaveMovimientoResource movimiento);

        Task<MovimientoResponse> UpdateAsync(int id, Movimiento movimiento);

        Task<MovimientoResponse> DeleteAsync(int id);
    }
}