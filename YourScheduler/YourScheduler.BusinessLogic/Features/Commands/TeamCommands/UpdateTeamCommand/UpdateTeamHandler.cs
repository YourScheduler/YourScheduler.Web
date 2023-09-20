using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.UpdateTeamCommand;

public class UpdateTeamHandler : IRequestHandler<TeamDto>
{
    private readonly ITeamService _teamService;
    public UpdateTeamHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<Unit> Handle(TeamDto request, CancellationToken cancellationToken)
    {
        await _teamService.UpdateTeamAsync(request);
        return Unit.Value;
    }
}
