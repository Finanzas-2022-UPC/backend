using FinanzasGrupo2API.Shared.Persistence.Contexts;

namespace FinanzasGrupo2API.Shared.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
