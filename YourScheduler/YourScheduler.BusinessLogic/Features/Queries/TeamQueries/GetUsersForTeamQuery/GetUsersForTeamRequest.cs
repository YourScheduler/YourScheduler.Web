using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetUsersForTeamQuery;

public class GetUsersForTeamRequest : IRequest<IEnumerable<ApplicationUserDto>>
{
    public int TeamtId { get; set; }
}
