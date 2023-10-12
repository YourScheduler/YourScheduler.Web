namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int userId, int teamId);
    }
}4