using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.CustomExceptions;
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
            return  _dbContext.Teams;
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            _logger.LogInformation("User attempt to add new team at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.Teams.AddAsync(team);
            await _dbContext.SaveChangesAsync();

            return team;
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to get team by ID at {DT}", DateTime.Now.ToLongTimeString());
            Team retrievedTeam = await _dbContext.Teams.FirstOrDefaultAsync(t => t.TeamId == id) ?? throw new TeamNotFoundException();
            return retrievedTeam;
        }
        public async Task DeleteTeamByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to delete team by ID at {DT}", DateTime.Now.ToLongTimeString());
            var teamToDelete = await GetTeamByIdAsync(id);

            _dbContext.Teams.Remove(teamToDelete);
            var applicationUserTeamsToDelete = _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamToDelete.TeamId);
            _dbContext.ApplicationUsersTeams.RemoveRange(applicationUserTeamsToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Team> UpdateTeamAsync(Team teamToBase)
        {
            _logger.LogInformation("User attempt to update team by ID at {DT}", DateTime.Now.ToLongTimeString());
            var teamToUpdate = await GetTeamByIdAsync(teamToBase.TeamId);

            teamToUpdate.Name = teamToBase.Name;
            teamToUpdate.Description = teamToBase.Description;
            teamToUpdate.Message = teamToBase.Message;

            if (teamToBase.PicturePath is null)
            {
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                teamToUpdate.PicturePath = teamToBase.PicturePath;
                await _dbContext.SaveChangesAsync();
            }
            return teamToBase;
        }

        public IQueryable<Team> GetTeamsForUserQueryable(int applicationUserId)
        {
            _logger.LogInformation("User attempt to get user's team at {DT}", DateTime.Now.ToLongTimeString());
            IQueryable<Team> retrievedTeams = _dbContext.ApplicationUsersTeams.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Team);
            return retrievedTeams;
        }

        public IQueryable<ApplicationUser> GetAllTeamMembersForTeamQueryable(int teamId)
        {
            _logger.LogInformation("User attempt to get other users for team at {DT}", DateTime.Now.ToLongTimeString());
            IQueryable<ApplicationUser> retrievedMembers = _dbContext.ApplicationUsersTeams.Where(x => x.TeamId == teamId).Select(x => x.ApplicationUser);
            return retrievedMembers;
        }

        public async Task<bool> VerifyIsTeamMemberAsync(int loggedUserId, int teamId)
        {
            return await _dbContext.ApplicationUsersTeams.AnyAsync(e => e.ApplicationUserId == loggedUserId && e.TeamId == teamId);
        }

      
    }


}
