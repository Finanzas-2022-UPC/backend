using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Domain.Services.Communication;
using FinanzasGrupo2API.DatasFrances.Resources;

namespace FinanzasGrupo2API.DatasFrances.Domain.Services
{
    public interface IDataFrancesService
    {
        Task<IEnumerable<Models.DataFrances>> ListAsync(int? proyectos_id);
        
        Task<Models.DataFrances> GetById(int id);

        Task<DataFrancesResponse> SaveAsync(SaveDataFrancesResource dataFrances);

        Task<DataFrancesResponse> UpdateAsync(int id, Models.DataFrances dataFrances);

        Task<DataFrancesResponse> DeleteAsync(int id);
    }
}