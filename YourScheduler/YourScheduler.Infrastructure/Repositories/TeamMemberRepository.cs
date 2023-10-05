using Microsoft.EntityFrameworkCore;
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

        public async Task AddTeamMemberAsync(int userId, int teamRoleId, int teamId)
        {
            _logger.LogInformation("User attempt to add team to user at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.ApplicationUsersTeams.AddAsync(new ApplicationUserTeams { ApplicationUserId = userId, TeamId = teamId, TeamRoleId = teamRoleId });
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
    }
}
