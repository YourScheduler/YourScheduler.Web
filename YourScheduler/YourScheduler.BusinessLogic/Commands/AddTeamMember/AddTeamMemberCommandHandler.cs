using MediatR;
using YourScheduler.BusinessLogic.Commands.RequestTeamInivte;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddTeamMember
{
    public class AddTeamMemberCommandHandler : IRequestHandler<AddTeamMemberCommand,string>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamsRepository _teamsRepository;
        private readonly IMediator _mediator;

        public AddTeamMemberCommandHandler(ITeamMemberRepository teamMemberRepository, ITeamsRepository teamsRepository, IMediator mediator)
        {
            _teamMemberRepository = teamMemberRepository;
            _teamsRepository = teamsRepository;
            _mediator = mediator;
        }

        public async Task<string> Handle(AddTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamsRepository.GetTeamByIdAsync(request.TeamId);
            if (team.IsPrivate)
            {
                await _mediator.Send(new RequestTeamInviteCommand(request.UserId, request.TeamId));
                return "Request for invitation has been sent to the Team Administrators";
            }
            else
            {
                await _teamMemberRepository.AddTeamMemberAsUserAsync(request.UserId, request.TeamId);
                return "User successfully added to the team";
            }
        }
    }
}
