using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        IQueryable<ApplicationUser> GetUsersFromDataBaseQueryable();
        Task<ApplicationUser> GetUserByIdAsync(int id);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        public Task<ApplicationUser> AddUserAsync(ApplicationUser user);
    }
}
