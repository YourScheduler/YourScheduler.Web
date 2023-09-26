using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetTeamRoleById
{
    public class GetTeamRoleByIdQuery : IRequest<TeamRoleDto>
    {
        public int TeamRoleId { get; }

        public GetTeamRoleByIdQuery(int teamRoleId)
        {
            TeamRoleId = teamRoleId;
        }
    }
}
