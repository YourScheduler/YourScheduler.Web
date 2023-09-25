using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Queries.GetAllTeamRolesForTeam
{
    public class GetAllTeamRolesForTeamQuery : IRequest<IEnumerable<TeamRole>>
    {
        public int TeamId { get; }

        public GetAllTeamRolesForTeamQuery(int teamId)
        {
            TeamId = teamId;
        }
    }
}
