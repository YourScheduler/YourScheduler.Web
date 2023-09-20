using MediatR;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.DeleteTeamCommand;

public class DeleteTeamRequest : IRequest
{
    public int Id { get; set; } 
}
