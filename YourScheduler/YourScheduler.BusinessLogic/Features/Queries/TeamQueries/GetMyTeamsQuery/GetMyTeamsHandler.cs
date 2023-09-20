using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetMyTeamsQuery;

public class GetMyTeamsHandler : IRequestHandler<GetMyTeamsRequest, IEnumerable<TeamDto>>
{
    private readonly ITeamService _teamService;
    public GetMyTeamsHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<IEnumerable<TeamDto>> Handle(GetMyTeamsRequest request, CancellationToken cancellationToken)
    {
        return await _teamService.GetMyTeamsAsync(request.ApplicationUserId, request.SearchString);
    }
}
