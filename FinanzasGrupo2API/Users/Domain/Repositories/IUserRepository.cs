namespace FinanzasGrupo2API.Users.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
        bool ExistsByUsername(string username);
        void Update(User user);
        void Remove(User user);
        Task<User> FindByEmailAsync(string email);
    }
}
