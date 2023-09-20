using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetTeamByIdQuery;

public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdRequest, TeamDto>
{
    private readonly ITeamService _teamService;
    public GetTeamByIdHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public async Task<TeamDto> Handle(GetTeamByIdRequest request, CancellationToken cancellationToken)
    {
       return await _teamService.GetTeamByIdAsync(request.Id, request.LoggedUserId);
    }
}
