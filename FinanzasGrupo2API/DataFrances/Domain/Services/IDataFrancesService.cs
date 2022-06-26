using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Domain.Services.Communication;
using FinanzasGrupo2API.DataFrancess.Resources;

namespace FinanzasGrupo2API.DataFrancess.Domain.Services
{
    public interface IDataFrancesService
    {
        Task<IEnumerable<Models.DataFrances>> ListAsync();
        
        Task<Models.DataFrances> GetById(int id);

        Task<DataFrancesResponse> SaveAsync(SaveDataFrancesResource dataFrances);

        Task<DataFrancesResponse> UpdateAsync(int id, Models.DataFrances dataFrances);

        Task<DataFrancesResponse> DeleteAsync(int id);
    }
}