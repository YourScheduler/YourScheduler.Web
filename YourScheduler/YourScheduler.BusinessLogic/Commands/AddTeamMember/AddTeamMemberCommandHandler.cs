using MediatR;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddTeamMember
{
    public class AddTeamMemberCommandHandler : IRequestHandler<AddTeamMemberCommand>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public AddTeamMemberCommandHandler(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task Handle(AddTeamMemberCommand request, CancellationToken cancellationToken)
        {
            await _teamMemberRepository.AddTeamMemberAsync(request.UserId, request.TeamRoleId, request.TeamId);
        }
    }
}
