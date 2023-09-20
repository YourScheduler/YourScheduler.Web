using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.AddTeamCommand;

public class AddTeamHandler : IRequestHandler<TeamDto>
{
    private readonly ITeamService _teamService;
    public AddTeamHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }

    public async Task<Unit> Handle(TeamDto request, CancellationToken cancellationToken)
    {
        await _teamService.AddTeamAsync(request);
        return Unit.Value;
    }
}
