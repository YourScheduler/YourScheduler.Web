using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommand : IRequest<TeamRoleDto>
    {
        public TeamRoleDto TeamRoleDto { get; }

        public UpdateTeamRoleCommand(TeamRoleDto teamRoleDto)
        {
            TeamRoleDto = teamRoleDto;
        }
    }
}
