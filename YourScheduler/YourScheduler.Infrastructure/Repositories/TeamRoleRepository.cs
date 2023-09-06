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

        public async Task AddTeamRoleAsync(TeamRole teamRole, int teamId)
        {
            var teamForNewRole = await _dbContext.Teams.SingleOrDefaultAsync(t => t.TeamId == teamId) ?? throw new Exception ("Could not find team with given id");
            teamForNewRole.TeamRoles.Add(teamRole);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeamRoleAsync(TeamRole teamRoleToUpdate, int teamId)
        {
            var teamForNewRole = await _dbContext.Teams.SingleOrDefaultAsync(t => t.TeamId == teamId) ?? throw new Exception("Could not find team with given id");
            var roleInTeam = teamForNewRole.TeamRoles.FirstOrDefault(r => r.TeamRoleId == teamRoleToUpdate.TeamRoleId) ?? throw new Exception("Could not find team role with given id");

            roleInTeam.Name = teamRoleToUpdate.Name;
            roleInTeam.TeamRoleFlags = teamRoleToUpdate.TeamRoleFlags;
            await _dbContext.SaveChangesAsync();

        }

        public async Task RemoveTeamRoleByIdAsync(int teamRoleId, int teamId)
        {
            var teamForRoleDeletion = await _dbContext.Teams.SingleOrDefaultAsync(t => t.TeamId == teamId) ?? throw new Exception("Could not find team with given id");
            var roleToBeDeleted = teamForRoleDeletion.TeamRoles.FirstOrDefault(r => r.TeamRoleId == teamRoleId) ?? throw new Exception("Could not find team role with given id");
            teamForRoleDeletion.TeamRoles.Remove(roleToBeDeleted);
        }
    }
}
