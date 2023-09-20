using MediatR;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.AddTeamForUserCommand;

public class AddTeamForUserHandler : IRequestHandler<AddTeamForUserRequest>
{
    private readonly ITeamService _teamService;
    public AddTeamForUserHandler(ITeamService teamService)
    {
        _teamService = teamService;
    }
    public async Task<Unit> Handle(AddTeamForUserRequest request, CancellationToken cancellationToken)
    {
        await _teamService.AddTeamForUserAsync(request.ApplicationUserId, request.TeamId);
        return Unit.Value;
    }
}
