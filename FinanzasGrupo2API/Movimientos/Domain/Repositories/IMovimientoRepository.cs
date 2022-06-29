using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Movimientos.Domain.Models;

namespace FinanzasGrupo2API.Movimientos.Domain.Repositories
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> ListAsync();

        Task AddAsync(Movimiento movimiento);

        Task<Movimiento> FindByIdAsync(int id);

        Task<IEnumerable<Movimiento>> ListByCrudId(int crud_id);

        void Update(Movimiento movimiento);
        
        void Remove(Movimiento movimiento);
    }
}