using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public TeamMemberRepository(YourSchedulerDbContext dbContext, ILogger<TeamMemberRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddTeamMemberAsync(int userId, int teamId)
        {
            _logger.LogInformation("User attempt to add team to user at {DT}", DateTime.Now.ToLongTimeString());

            await _dbContext.ApplicationUsersTeams.AddAsync(new ApplicationUserTeams { ApplicationUserId = userId, TeamId = teamId, TeamRoleId = 1}); // TeamRoleId 1 is always invitee which cannot see content of the team without accepting invite first
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveTeamMemberAsync(int userId, int teamId)
        {
            _logger.LogInformation("User attempt to remove team to user at {DT}", DateTime.Now.ToLongTimeString());
            var teamMember = await _dbContext.ApplicationUsersTeams
                .FirstOrDefaultAsync(tm => tm.ApplicationUserId == userId && tm.TeamId == teamId) 
                ?? throw new Exception("TeamMember not found!");
            
            _dbContext.ApplicationUsersTeams.Remove(teamMember);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeamMemberRoleAsync(int userId, int teamRoleId, int teamId)
        {
            _logger.LogInformation("User attempt to update team member role {DT}", DateTime.Now.ToLongTimeString());
            var teamMember = await _dbContext.ApplicationUsersTeams
                .FirstOrDefaultAsync(tm => tm.ApplicationUserId == userId && tm.TeamId == teamId) 
                ?? throw new Exception("TeamMember not found!");

            teamMember.TeamRoleId = teamRoleId;
            _dbContext.ApplicationUsersTeams.Update(teamMember);

            await _dbContext.SaveChangesAsync();
        }
        public async Task InviteTeamMemberAsync(int userId, int teamId)
        {
            
        }
        public async Task RequestInvitationToTeam(int userId, int teamId)
        {

        }
        public async Task TeamMemberAcceptedInvitation(string token)
        {

        }
    }
}
