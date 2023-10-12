using MediatR;

namespace YourScheduler.BusinessLogic.Commands.RequestTeamInivte
{
    public class RequestTeamInviteCommand : IRequest
    {
        public int UserId { get;}
        public int TeamId { get;}

        public RequestTeamInviteCommand(int userId, int teamId)
        {
            UserId = userId;
            TeamId = teamId;
        }
    }
}
