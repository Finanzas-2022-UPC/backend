using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Services.Communication;
using FinanzasGrupo2API.Cruds.Resources;

namespace FinanzasGrupo2API.Cruds.Domain.Services
{
    public interface ICrudService
    {
        Task<IEnumerable<Crud>> ListAsync(string ?type, int ?projectId);
        
        Task<Crud> GetById(int id);

        Task<CrudResponse> SaveAsync(SaveCrudResource crud);

        Task<CrudResponse> UpdateAsync(int id, Crud crud);

        Task<CrudResponse> DeleteAsync(int id);
    }
}