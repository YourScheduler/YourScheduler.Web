using MediatR;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.AddTeamForUserCommand;

public class AddTeamForUserRequest : IRequest
{
    public int ApplicationUserId { get; set; }
    public int TeamId { get; set; }
}
