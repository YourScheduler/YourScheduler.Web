using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleCommand : IRequest<TeamRoleDto>
    {
        public TeamRole TeamRole { get; }

        public AddTeamRoleCommand(TeamRole teamRole)
        {
            TeamRole = teamRole;
        }
    }
}
