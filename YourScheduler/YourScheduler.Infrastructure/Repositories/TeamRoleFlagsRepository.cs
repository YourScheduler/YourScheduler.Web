using Microsoft.Extensions.Logging;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamRoleFlagsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public TeamRoleFlagsRepository(YourSchedulerDbContext dbContext, ILogger<TeamsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
