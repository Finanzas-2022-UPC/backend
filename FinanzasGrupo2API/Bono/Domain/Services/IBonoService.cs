using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Bonos.Domain.Services.Communication;
using FinanzasGrupo2API.Bonos.Resources;

namespace FinanzasGrupo2API.Bonos.Domain.Services
{
    public interface IBonoService
    {
        Task<IEnumerable<Bono>> ListAsync();
        
        Task<Bono> GetById(int id);

        Task<BonoResponse> SaveAsync(SaveBonoResource bono);

        Task<BonoResponse> UpdateAsync(int id, Bono bono);

        Task<BonoResponse> DeleteAsync(int id);
    }
}