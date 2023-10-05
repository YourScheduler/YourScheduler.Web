using MediatR;
using YourScheduler.Infrastructure.Repositories;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.RemoveTeamMember
{
    public class RemoveTeamMemberCommandHandler : IRequestHandler<RemoveTeamMemberCommand>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public RemoveTeamMemberCommandHandler(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task Handle(RemoveTeamMemberCommand request, CancellationToken cancellationToken)
        {
            await _teamMemberRepository.RemoveTeamMemberAsync(request.UserId, request.TeamId);
        }
    }
}
