using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommand : IRequest<TeamRoleDto>
    {
        public TeamRole TeamRole { get; }

        public UpdateTeamRoleCommand(TeamRole teamRole)
        {
            TeamRole = teamRole;
        }
    }
}
