
using MediatR;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.BusinessLogic.Commands.AuthorizeUser
{
    public class AuthorizeUserCommand : IRequest<AuthorizationResponse>
    {
        public AuthorizationRequest AuthorizationRequest { get; }

        public AuthorizeUserCommand(AuthorizationRequest authorizationRequest)
        {
            AuthorizationRequest = authorizationRequest;
        }
    }
}
