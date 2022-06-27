using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Projects.Domain.Models;

namespace FinanzasGrupo2API.Projects.Domain.Repositories
{
    public interface IProyectoRepository
    {
        Task<IEnumerable<Proyecto>> ListAsync();
        
        Task AddAsync(Proyecto project);

        Task<Proyecto> FindByIdAsync(int id);

        void Update(Proyecto project);
        
        void Remove(Proyecto project);
    }
}