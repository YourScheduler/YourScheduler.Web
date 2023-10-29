using System.Security.Claims;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(List<Claim> claims);
    }
}