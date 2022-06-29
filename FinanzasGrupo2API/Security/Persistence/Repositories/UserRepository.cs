using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Security.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task AddAsync(Usuario user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.id == id);
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.email == email);
        }

        public async Task<Usuario> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.email == email);
        }
        
        public void Update(Usuario user)
        {
            _context.Users.Update(user);
        }

        public void Remove(Usuario user)
        {
            _context.Users.Remove(user);
        }
    }
}