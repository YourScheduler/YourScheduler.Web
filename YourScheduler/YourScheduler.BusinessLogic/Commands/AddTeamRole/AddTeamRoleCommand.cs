using MediatR;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleCommand : IRequest<TeamRole>
    {
        public TeamRole TeamRole { get; }

        public AddTeamRoleCommand(TeamRole teamRole)
        {
            TeamRole = teamRole;
        }
    }
}
