using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public TeamsRepository(YourSchedulerDbContext dbContext, ILogger<TeamsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IQueryable<Team> GetAllExistedTeamsQueryable()
        {
            return _dbContext.Teams;
        }

        public async Task<List<Team>> GetAllExistedTeamsAsync()
        {
            _logger.LogInformation("User attempt to get all teams at {DT}", DateTime.Now.ToLongTimeString());
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task AddTeamAsync(Team team)
        {
            _logger.LogInformation("User attempt to add new team at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.Teams.AddAsync(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to get team by ID at {DT}", DateTime.Now.ToLongTimeString());
            return await _dbContext.Teams.FirstOrDefaultAsync(t => t.TeamId == id);  
        }

        public async Task DeleteTeamByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to delete team by ID at {DT}", DateTime.Now.ToLongTimeString());
            var teamToDelete = await GetTeamByIdAsync(id);
            if (teamToDelete != null)
            {
                _dbContext.Teams.Remove(teamToDelete);
                var applicationUserTeamsToDelete = _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamToDelete.TeamId);
                _dbContext.ApplicationUsersTeams.RemoveRange(applicationUserTeamsToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTeamAsync(Team teamToBase)
        {
            _logger.LogInformation("User attempt to update team by ID at {DT}", DateTime.Now.ToLongTimeString());
            var teamToUpdate = await _dbContext.Teams.SingleOrDefaultAsync(e => e.TeamId == teamToBase.TeamId);
            if (teamToUpdate != null)
            {
                teamToUpdate.Name = teamToBase.Name;
                teamToUpdate.Description = teamToBase.Description;
                if (teamToBase.PicturePath is null)
                {
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    teamToUpdate.PicturePath = teamToBase.PicturePath;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task AddTeamMemberAsync(int applicationUserId, int teamId)
        {
            _logger.LogInformation("User attempt to add team to user at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.ApplicationUsersTeams.AddAsync(new ApplicationUserTeams { ApplicationUserId = applicationUserId, TeamId = teamId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Team>> GetTeamsForUserAsync(int applicationUserId)
        {
            _logger.LogInformation("User attempt to get user's team at {DT}", DateTime.Now.ToLongTimeString());
            return await _dbContext.ApplicationUsersTeams.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Team).ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetTeamMembersForTeamAsync(int teamId)
        {
            _logger.LogInformation("User attempt to get other users for team at {DT}", DateTime.Now.ToLongTimeString());
            return await _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamId).Select(x => x.ApplicationUser).ToListAsync();
        }

        public async Task<bool> VerifyIsTeamMember(int loggedUserId, int teamId)
        {
            return await _dbContext.ApplicationUsersTeams.AnyAsync(e => e.ApplicationUserId == loggedUserId && e.TeamId == teamId);
        }

        
    }


}
