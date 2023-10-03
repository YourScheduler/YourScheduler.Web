using MediatR;

namespace YourScheduler.BusinessLogic.Commands.AddTeamMember
{
    public class AddTeamMemberCommand : IRequest
    {
        public int UserId { get;}
        public int TeamRoleId { get;}
        public int TeamId { get;}

        public AddTeamMemberCommand(int userId, int teamRoleId, int teamId)
        {
            UserId = userId;
            TeamRoleId = teamRoleId;
            TeamId = teamId;
        }
    }
}
