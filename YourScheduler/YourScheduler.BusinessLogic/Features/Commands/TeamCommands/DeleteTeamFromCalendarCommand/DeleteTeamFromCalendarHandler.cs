using MediatR;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.DeleteTeamFromCalendarCommand;

public class DeleteTeamFromCalendarHandler : IRequestHandler<DeleteTeamFromCalendarRequest>
{
    private readonly ITeamService _teamService;
    public DeleteTeamFromCalendarHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<Unit> Handle(DeleteTeamFromCalendarRequest request, CancellationToken cancellationToken)
    {
        await _teamService.DeleteTeamFromCalendarAsync(request.Id, request.UserId);
        return Unit.Value;
    }
}
