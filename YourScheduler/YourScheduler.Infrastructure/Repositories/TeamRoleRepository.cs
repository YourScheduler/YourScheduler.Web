using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamRoleRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public TeamRoleRepository(YourSchedulerDbContext dbContext, ILogger<TeamsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IQueryable<TeamRole> GetAllTeamRolesForTeamQueryable(int teamId)
        {
            return _dbContext.ApplicationUsersTeams
                .Include(tr => tr.TeamRole)
                .Where(tr => tr.TeamId == teamId)
                .Select(tr => tr.TeamRole);
        }

        public async Task<TeamRole> AddTeamRoleAsync(TeamRole teamRole, int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<TeamRole> UpdateTeamRoleAsync(TeamRole teamRoleToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<TeamRole> RemoveTeamRoleByIdAsync(int teamRoleId)
        {
            throw new NotImplementedException();
        }
    }
}
