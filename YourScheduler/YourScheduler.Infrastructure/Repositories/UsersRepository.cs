using Microsoft.EntityFrameworkCore;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public UsersRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public IQueryable<ApplicationUser> GetUsersFromDataBaseQueryable()
        {
            return _dbContext.Users;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return  await _dbContext.ApplicationUsers.FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception("Could not find a user with specified email");
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            return await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("Could not find a user with specified id");
        }

    }
}
