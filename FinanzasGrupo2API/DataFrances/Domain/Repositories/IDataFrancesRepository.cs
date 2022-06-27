using FinanzasGrupo2API.DatasFrances.Domain.Models;

namespace FinanzasGrupo2API.DatasFrances.Domain.Repositories
{
    public interface IDataFrancesRepository
    {
        Task<IEnumerable<Models.DataFrances>> ListAsync();
        
        Task AddAsync(Models.DataFrances dataFrances);

        Task<Models.DataFrances> FindByIdAsync(int id);

        void Update(Models.DataFrances dataFrances);
        
        void Remove(Models.DataFrances dataFrances);
    }
}