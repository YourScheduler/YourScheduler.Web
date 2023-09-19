using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
