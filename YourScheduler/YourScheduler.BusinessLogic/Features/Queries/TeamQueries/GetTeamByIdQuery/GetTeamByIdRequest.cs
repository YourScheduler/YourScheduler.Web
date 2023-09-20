using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetTeamByIdQuery;

public class GetTeamByIdRequest: IRequest<TeamDto>
{
    public int Id { get; set; }
    public int LoggedUserId { get; set; }
}
