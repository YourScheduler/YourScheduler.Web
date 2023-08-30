using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface ITeamService
    {
        public Task AddTeamAsync(TeamDto teamDto);

        public Task<List<TeamDto>> GetAvailableTeamsAsync(int loggedUserId, string searchString);

        public Task<TeamDto> GetTeamByIdAsync(int id,int loggedUserId);

        public Task DeleteTeamAsync(int id);

        public Task DeleteTeamFromCalendarAsync(int id, int userId);

        public Task UpdateTeamAsync(TeamDto teamDto);

        public Task AddTeamForUserAsync(int applicationUserId, int teamId);

        public Task<List<TeamDto>> GetMyTeamsAsync(int applicationUserId,string searchString);

        public Task<List<ApplicationUserDto>> GetUsersForTeamAsync(int teamid);
    }
}
