using MediatR;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.DeleteTeamCommand;

public class DeleteTeamHandler : IRequestHandler<DeleteTeamRequest>
{
    private readonly ITeamService _teamService;
    public DeleteTeamHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<Unit> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        await _teamService.DeleteTeamAsync(request.Id);
        return Unit.Value;
    }
}
