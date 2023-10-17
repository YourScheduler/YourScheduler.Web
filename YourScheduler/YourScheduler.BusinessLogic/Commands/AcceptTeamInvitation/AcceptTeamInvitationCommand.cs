using MediatR;

namespace YourScheduler.BusinessLogic.Commands.AcceptTeamInvitation
{
    public class AcceptTeamInvitationCommand : IRequest<string>
    {
        public string Token { get;}

        public AcceptTeamInvitationCommand(string token)
        {
            Token = token;
        }
    }
}
