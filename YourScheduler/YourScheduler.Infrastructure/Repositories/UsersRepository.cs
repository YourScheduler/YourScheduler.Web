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

        public void AddUser(ApplicationUser user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public IQueryable<ApplicationUser> GetUsersFromDataBaseQueryable()
        {
            return _dbContext.Users;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            var retrievedUser = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == email) ?? throw new Exception("Could not find a user with specified email");
            return retrievedUser;
        }

        public ApplicationUser GetUserById(int id)
        {
            var retrievedUser = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == id) ?? throw new Exception("Could not find a user with specified id");
            return retrievedUser;
        }

    }
}
