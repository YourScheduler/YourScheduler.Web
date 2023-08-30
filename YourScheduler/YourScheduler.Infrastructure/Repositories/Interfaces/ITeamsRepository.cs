using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        public Task<List<Team>> GetAllExistedTeamsAsync();

        public Task AddTeamAsync(Team team);

        public Task<Team?> GetTeamByIdAsync(int id);

        public Task DeleteTeamByIdAsync(int id);

        public Task DeleteTeamFromCalendarByIdAsync(int id, int userId);

        public Task UpdateTeamAsync(Team teamToBase);

        public Task AddTeamForUserAsync(int applicationUserId, int teamId);

        public Task<List<Team>> GetTeamsForUserAsync(int applicationUserId);

        public Task<List<ApplicationUser>> GetApplicationUsersForTeamAsync(int teamId);

        public Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int teamId);

    }
}
