using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleCommand : IRequest<TeamRoleDto>
    {
        public TeamRoleDto TeamRoleDto { get; }

        public AddTeamRoleCommand(TeamRoleDto teamRoleDto)
        {
            TeamRoleDto = teamRoleDto;
        }
    }
}
