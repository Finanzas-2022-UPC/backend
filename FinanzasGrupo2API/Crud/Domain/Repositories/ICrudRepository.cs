using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Cruds.Domain.Models;

namespace FinanzasGrupo2API.Cruds.Domain.Repositories
{
    public interface ICrudRepository
    {
        Task<IEnumerable<Crud>> ListAsync();
        
        Task AddAsync(Crud crud);

        Task<Crud> FindByIdAsync(int id);

        void Update(Crud crud);
        
        void Remove(Crud crud);
    }
}