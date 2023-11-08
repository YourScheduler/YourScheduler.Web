using MediatR;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamMemberRole
{
    public class UpdateTeamMemberRoleCommand : IRequest
    {
        public int UserId { get; }
        public int TeamRoleId { get; }
        public int TeamId { get; }

        public UpdateTeamMemberRoleCommand(int userId, int teamRoleId, int teamId)
        {
            UserId = userId;
            TeamRoleId = teamRoleId;
            TeamId = teamId;
        }
    }
}
