using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        public IQueryable<Team> GetAllExistedTeamsQueryable();

        public Task AddTeamAsync(Team team);

        public Task<Team> GetTeamByIdAsync(int id);

        public Task DeleteTeamByIdAsync(int id);

        public Task UpdateTeamAsync(Team teamToBase);

        public IQueryable<Team> GetTeamsForUserQueryable(int applicationUserId);

        public IQueryable<ApplicationUser> GetAllTeamMembersForTeamQueryable(int teamId);

        public Task<bool> VerifyIsTeamMemberAsync(int loggedUserId, int teamId);

    }
}
