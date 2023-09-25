using MediatR;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Queries.GetTeamRoleById
{
    public class GetTeamRoleByIdQuery : IRequest<TeamRole>
    {
        public int TeamRoleId { get; set; }

        public GetTeamRoleByIdQuery(int teamRoleId)
        {
            TeamRoleId = teamRoleId;
        }
    }
}
