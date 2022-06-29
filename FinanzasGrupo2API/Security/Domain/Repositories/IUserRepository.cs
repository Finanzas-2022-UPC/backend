using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Security.Domain.Models;

namespace FinanzasGrupo2API.Security.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListAsync();
        Task AddAsync(Usuario user);
        Task<Usuario> FindByIdAsync(int id);
        bool ExistsByEmail(string email);
        void Update(Usuario user);
        void Remove(Usuario user);
        Task<Usuario> FindByEmailAsync(string email);
    }
}