using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamRoleRepository : ITeamRoleRepository
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
            return _dbContext.TeamRoles
                .Where(tr => tr.TeamId == teamId);
        }

        public async Task<TeamRole> GetTeamRoleByIdAsync(int teamRoleId)
        {
            return await _dbContext.TeamRoles.FindAsync(teamRoleId) ?? throw new ArgumentNullException("Could not find a TeamRole with given Id");
        }

        public async Task<TeamRole> AddTeamRoleAsync(TeamRole teamRole)
        {
            await _dbContext.TeamRoles.AddAsync(teamRole);
            await _dbContext.SaveChangesAsync();
            return teamRole;
        }

        public async Task<TeamRole> UpdateTeamRoleAsync(TeamRole teamRoleToUpdate)
        {
            _dbContext.Update(teamRoleToUpdate);
            await _dbContext.SaveChangesAsync();

            return teamRoleToUpdate;

        }

        public async Task RemoveTeamRoleByIdAsync(int teamRoleId)
        {
            var teamRoleToRemove = await GetTeamRoleByIdAsync(teamRoleId) ?? throw new ArgumentNullException("TeamRole not found");

            _dbContext.Remove(teamRoleToRemove);
            await _dbContext.SaveChangesAsync();

        }
    }
}
