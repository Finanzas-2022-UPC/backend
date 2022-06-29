using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Services.Communication;
using FinanzasGrupo2API.Projects.Resources;

namespace FinanzasGrupo2API.Projects.Domain.Services
{
    public interface IProyectoService
    {
        Task<IEnumerable<Proyecto>> ListAsync(int ? userId);
        
        Task<Proyecto> GetById(int id);

        Task<ProyectoResponse> SaveAsync(SaveProyectoResource project);

        Task<ProyectoResponse> UpdateAsync(int id, Proyecto project);

        Task<ProyectoResponse> DeleteAsync(int id);
    }
}