using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ITeamRoleRepository _teamRoleRepository;
        private readonly ILogger _logger;

        public TeamMemberRepository(YourSchedulerDbContext dbContext, ILogger<TeamMemberRepository> logger, ITeamRoleRepository teamRoleRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task AddTeamMemberAsInvteeAsync(int userId, int teamId)
        {
            var sortedTeamRoles = _teamRoleRepository.GetAllTeamRolesForTeamQueryable(teamId).ToList().OrderBy(s => s.TeamRoleId);
            _logger.LogInformation("User attempt to add team to user at {DT}", DateTime.Now.ToLongTimeString());

            await _dbContext.ApplicationUsersTeams.AddAsync(new ApplicationUserTeams { ApplicationUserId = userId, TeamId = teamId, TeamRoleId = sortedTeamRoles.ToList()[0].TeamRoleId }); // Lowest TeamRoleId in Team always means it has flagId = 1 and is invitee
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTeamMemberAsUserAsync(int userId, int teamId)
        {
            var sortedTeamRoles = _teamRoleRepository.GetAllTeamRolesForTeamQueryable(teamId).OrderBy(s => s.TeamRoleId).ToList();
            var teamMember = await _dbContext.ApplicationUsersTeams
                .FirstOrDefaultAsync(tm => tm.ApplicationUserId == userId && tm.TeamId == teamId);

            if (teamMember is not null && teamMember.TeamRoleId == sortedTeamRoles[0].TeamRoleId)
            {
                _logger.LogInformation("User accepted invite or was approved to join by the administrator at {DT}", DateTime.Now.ToLongTimeString());
                await UpdateTeamMemberRoleAsync(userId, sortedTeamRoles[2].TeamRoleId, teamId);
            }
            else
            {
                _logger.LogInformation("User attempted to join team as user at {DT}", DateTime.Now.ToLongTimeString());
                await _dbContext.ApplicationUsersTeams.AddAsync(new ApplicationUserTeams { ApplicationUserId = userId, TeamId = teamId, TeamRoleId = sortedTeamRoles[2].TeamRoleId }); // 3rd TeamRoleId in Team always means it has flagId = 3 and is user
                await _dbContext.SaveChangesAsync();
            }  
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
            var updatedTeamMember = new ApplicationUserTeams { ApplicationUserId = userId, TeamId = teamId, TeamRoleId = teamRoleId };

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.ApplicationUsersTeams.Remove(teamMember);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.ApplicationUsersTeams.Add(updatedTeamMember);
                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
