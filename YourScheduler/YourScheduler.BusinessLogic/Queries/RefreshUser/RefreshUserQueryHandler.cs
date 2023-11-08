using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.CustomExceptions;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Queries.RefreshUser
{
    public class RefreshUserQueryHandler :IRequestHandler<RefreshUserQuery,AuthorizationResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtGenerator;

        public RefreshUserQueryHandler(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthorizationResponse> Handle(RefreshUserQuery request, CancellationToken cancellationToken)
        {
            int tokenExpiresInDays = 2;
            var user = await _userManager.FindByNameAsync(request.Email) ?? throw new UserByEmailNotFoundException();

            var token = _jwtGenerator.GenerateToken(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? throw new AuthorizationException("Wrong Email to generate Token")),
                new Claim(ClaimTypes.GivenName, user.Displayname)
            }, tokenExpiresInDays);

            return new AuthorizationResponse(user, token);

        }
    }
}
