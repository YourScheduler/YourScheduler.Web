using MediatR;

namespace YourScheduler.BusinessLogic.Commands.InviteTeamMember
{
    public class InviteTeamMemberCommand : IRequest
    {
        public int UserId { get; }
        public int TeamId { get; }

        public InviteTeamMemberCommand(int userId, int teamId)
        {
            UserId = userId;
            TeamId = teamId;
        }
    }
}
