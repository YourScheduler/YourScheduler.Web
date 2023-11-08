using MediatR;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.RemoveTeamRoleById
{
    public class RemoveTeamRoleByIdCommandHandler : IRequestHandler<RemoveTeamRoleByIdCommand>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;

        public RemoveTeamRoleByIdCommandHandler(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task Handle(RemoveTeamRoleByIdCommand request, CancellationToken cancellationToken)
        {
            await _teamRoleRepository.RemoveTeamRoleByIdAsync(request.TeamRoleId);
        }
    }
}
