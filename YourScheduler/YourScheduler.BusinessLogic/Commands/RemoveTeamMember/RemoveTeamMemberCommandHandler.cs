using MediatR;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Commands.RemoveTeamMember
{
    public class RemoveTeamMemberCommandHandler : IRequestHandler<RemoveTeamMemberCommand>
    {
        private readonly TeamMemberRepository _teamMemberRepository;

        public RemoveTeamMemberCommandHandler(TeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task Handle(RemoveTeamMemberCommand request, CancellationToken cancellationToken)
        {
            await _teamMemberRepository.RemoveTeamMemberAsync(request.UserId, request.TeamId);
        }
    }
}
