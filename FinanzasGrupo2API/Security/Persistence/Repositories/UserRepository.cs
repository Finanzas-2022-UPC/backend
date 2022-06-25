using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;
using FinanzasGrupo2API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanzasGrupo2API.Security.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Username == username);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Email == email);
        }
        
        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}