using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class HomeViewRepository : IHomeViewRepository
    {
        private readonly YourSchedulerDbContext _dbContext;

        public HomeViewRepository(YourSchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public HomeView GetDataHomeView(int id)
        {
            return _dbContext.HomeViews.FirstOrDefault(h => h.HomeViewId == id);
        }
    }
}
