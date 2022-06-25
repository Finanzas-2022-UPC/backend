using FinanzasGrupo2API.Shared.Domain.Repositories;
using FinanzasGrupo2API.Shared.Persistence.Contexts;

namespace FinanzasGrupo2API.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
