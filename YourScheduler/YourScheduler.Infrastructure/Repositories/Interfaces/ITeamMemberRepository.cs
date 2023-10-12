namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamMemberRepository
    {
        Task AddTeamMemberAsInvteeAsync(int userId, int teamId);
        Task AddTeamMemberAsUserAsync(int userId, int teamId);
        Task RemoveTeamMemberAsync(int userId, int teamId);
        Task UpdateTeamMemberRoleAsync(int userId, int teamRoleId, int teamId);
    }
}