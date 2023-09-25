using MediatR;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Commands.RemoveTeamRoleById
{
    public class RemoveTeamRoleByIdCommandHandler : IRequestHandler<RemoveTeamRoleByIdCommand>
    {
        private readonly TeamRoleRepository _teamRoleRepository;

        public RemoveTeamRoleByIdCommandHandler(TeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task Handle(RemoveTeamRoleByIdCommand request, CancellationToken cancellationToken)
        {
            await _teamRoleRepository.RemoveTeamRoleByIdAsync(request.TeamRoleId);
        }
    }
}
