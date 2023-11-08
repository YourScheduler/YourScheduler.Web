using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.CustomExceptions;
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
                .Include(tr => tr.TeamRoleFlags)
                .Where(tr => tr.TeamId == teamId);
        }

        public async Task<TeamRole> GetTeamRoleByIdAsync(int teamRoleId)
        {
            return await _dbContext.TeamRoles.FindAsync(teamRoleId) ?? throw new TeamRoleNotFoundException();
        }

        public async Task<TeamRole> AddTeamRoleAsync(TeamRole teamRole)
        {
            IfFlagInDbOverrideFlagId(teamRole);
            await _dbContext.TeamRoles.AddAsync(teamRole);
            await _dbContext.SaveChangesAsync();

            return teamRole;
        }

        public async Task<TeamRole> UpdateTeamRoleAsync(TeamRole teamRoleToUpdate)
        {
            IfFlagInDbOverrideFlagId(teamRoleToUpdate);
            _dbContext.Update(teamRoleToUpdate);
            await _dbContext.SaveChangesAsync();

            return teamRoleToUpdate;

        }

        public async Task RemoveTeamRoleByIdAsync(int teamRoleId)
        {
            var teamRoleToRemove = await GetTeamRoleByIdAsync(teamRoleId);

            _dbContext.Remove(teamRoleToRemove);
            await _dbContext.SaveChangesAsync();

        }

        public void IfFlagInDbOverrideFlagId(TeamRole teamRole)
        {
            foreach (TeamRoleFlags flag in _dbContext.TeamRolesFlags)
            {
                if (teamRole.TeamRoleFlags.Equals(flag))
                {
                    teamRole.TeamRoleFlagsId = flag.TeamRoleFlagsId;
                    break;
                }
            }
        }


        public int GetNumberOfRows()
        {
            return _dbContext.TeamRoles.Count();
        }
    }
}
