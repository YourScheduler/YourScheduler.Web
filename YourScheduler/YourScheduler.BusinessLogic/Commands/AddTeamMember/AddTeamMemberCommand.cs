using MediatR;

namespace YourScheduler.BusinessLogic.Commands.AddTeamMember
{
    public class AddTeamMemberCommand : IRequest<string>
    {
        public int UserId { get;}
        public int TeamId { get;}

        public AddTeamMemberCommand(int userId, int teamId)
        {
            UserId = userId;
            TeamId = teamId;
        }
    }
}
