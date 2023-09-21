using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetTeamById
{
    public class GetTeamByIdQuery : IRequest<TeamDto>
    {
        public int TeamId { get;}
        public GetTeamByIdQuery(int teamId)
        {
            TeamId = teamId;
        }
    }
}
