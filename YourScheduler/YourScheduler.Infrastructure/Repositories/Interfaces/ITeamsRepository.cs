using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        public IQueryable<Team> GetAllExistedTeamsQueryable();
        public Task<List<Team>> GetAllExistedTeamsAsync();

        public Task AddTeamAsync(Team team);

        public Task<Team?> GetTeamByIdAsync(int id);

        public Task DeleteTeamByIdAsync(int id);

        public Task UpdateTeamAsync(Team teamToBase);

        public Task AddTeamMemberAsync(int applicationUserId, int teamId);

        public Task<List<Team>> GetTeamsForUserAsync(int applicationUserId);

        public Task<List<ApplicationUser>> GetTeamMembersForTeamAsync(int teamId);

        public Task<bool> VerifyIsTeamMember(int loggedUserId, int teamId);

    }
}
