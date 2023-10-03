using MediatR;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamMemberRole
{
    public class UpdateTeamMemberRoleCommandHandler : IRequestHandler<UpdateTeamMemberRoleCommand>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public UpdateTeamMemberRoleCommandHandler(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task Handle(UpdateTeamMemberRoleCommand request, CancellationToken cancellationToken)
        {
            await _teamMemberRepository.UpdateTeamMemberRoleAsync(request.UserId, request.TeamRoleId, request.TeamId);
        }
    }
}
