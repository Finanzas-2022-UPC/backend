using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Bonos.Domain.Models;

namespace FinanzasGrupo2API.Bonos.Domain.Repositories
{
    public interface IBonoRepository
    {
        Task<IEnumerable<Bono>> ListAsync();
        
        Task AddAsync(Bono bono);

        Task<Bono> FindByIdAsync(int id);

        void Update(Bono bono);
        
        void Remove(Bono bono);
    }
}