using Microsoft.EntityFrameworkCore;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamRoleRepository
    {
        Task<TeamRole> AddTeamRoleAsync(TeamRole teamRole);
        IQueryable<TeamRole> GetAllTeamRolesForTeamQueryable(int teamId);
        Task<TeamRole> GetTeamRoleByIdAsync(int teamRoleId);
        Task RemoveTeamRoleByIdAsync(int teamRoleId);
        Task<TeamRole> UpdateTeamRoleAsync(TeamRole teamRoleToUpdate);

        public int GetNumberOfRows();
       
    }
}