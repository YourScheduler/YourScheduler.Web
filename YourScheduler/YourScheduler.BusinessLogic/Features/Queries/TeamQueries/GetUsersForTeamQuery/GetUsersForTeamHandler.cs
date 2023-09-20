using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetUsersForTeamQuery;

public class GetUsersForTeamHandler : IRequestHandler<GetUsersForTeamRequest, IEnumerable<ApplicationUserDto>>
{
    private readonly ITeamService _teamService;
    public GetUsersForTeamHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<IEnumerable<ApplicationUserDto>> Handle(GetUsersForTeamRequest request, CancellationToken cancellationToken)
    {
        return await _teamService.GetUsersForTeamAsync(request.TeamtId);
    }
}
