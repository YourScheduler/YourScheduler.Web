using MediatR;

namespace YourScheduler.BusinessLogic.Commands.RemoveTeamMember
{
    public class RemoveTeamMemberCommand : IRequest
    {
        public int UserId { get;}
        public int TeamId { get;}

        public RemoveTeamMemberCommand(int userId, int teamId)
        {
            UserId = userId;
            TeamId = teamId;
        }
    }
}
