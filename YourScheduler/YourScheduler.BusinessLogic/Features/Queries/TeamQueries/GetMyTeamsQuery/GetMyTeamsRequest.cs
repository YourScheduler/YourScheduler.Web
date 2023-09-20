using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetMyTeamsQuery;

public class GetMyTeamsRequest : IRequest<IEnumerable<TeamDto>>
{
    public int ApplicationUserId { get; set; }
    public string SearchString { get; set; }
}
