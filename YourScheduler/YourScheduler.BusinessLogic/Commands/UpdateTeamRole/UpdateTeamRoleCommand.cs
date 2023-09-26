using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommand : IRequest<TeamRoleDto>
    {
        public TeamRole TeamRoleDto { get; }

        public UpdateTeamRoleCommand(TeamRole teamRoleDto)
        {
            TeamRoleDto = teamRoleDto;
        }
    }
}
