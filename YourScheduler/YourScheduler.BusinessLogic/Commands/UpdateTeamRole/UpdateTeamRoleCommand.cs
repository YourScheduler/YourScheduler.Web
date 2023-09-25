using MediatR;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommand : IRequest<TeamRole>
    {
        public TeamRole TeamRole { get; }

        public UpdateTeamRoleCommand(TeamRole teamRole)
        {
            TeamRole = teamRole;
        }
    }
}
