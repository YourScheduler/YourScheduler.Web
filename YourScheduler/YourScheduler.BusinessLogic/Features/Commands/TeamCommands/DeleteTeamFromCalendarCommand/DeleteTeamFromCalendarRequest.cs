using MediatR;

namespace YourScheduler.BusinessLogic.Features.Commands.TeamCommands.DeleteTeamFromCalendarCommand;

public class DeleteTeamFromCalendarRequest : IRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
}
