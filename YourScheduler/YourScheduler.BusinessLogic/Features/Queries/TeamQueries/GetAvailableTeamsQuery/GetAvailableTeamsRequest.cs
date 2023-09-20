using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetAvailableTeamsQuery;

public class GetAvailableTeamsRequest : IRequest<IEnumerable<TeamDto>>
{
    public int LoggedUserId { get; set; }
    public string SearchString { get; set; }
}
