namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface ITeamMemberRepository
    {
        Task AddTeamMemberAsync(int userId, int teamId);
        Task RemoveTeamMemberAsync(int userId, int teamId);
        Task UpdateTeamMemberRoleAsync(int userId, int teamRoleId, int teamId);
    }
}