using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetAvailableTeamsQuery;

public class GetAvailableTeamsHandler : IRequestHandler<GetAvailableTeamsRequest, IEnumerable<TeamDto>>
{
    private readonly ITeamService _teamService;
    public GetAvailableTeamsHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public async Task<IEnumerable<TeamDto>> Handle(GetAvailableTeamsRequest request, CancellationToken cancellationToken)
    {
        return await _teamService.GetAvailableTeamsAsync(request.LoggedUserId,request.SearchString);
    }
}
