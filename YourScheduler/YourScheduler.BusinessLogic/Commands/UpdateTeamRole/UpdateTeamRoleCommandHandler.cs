using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommandHandler : IRequestHandler<UpdateTeamRoleCommand, TeamRole>
    {
        private readonly TeamRoleRepository _teamRoleRepository;

        public UpdateTeamRoleCommandHandler(TeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task<TeamRole> Handle(UpdateTeamRoleCommand request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.UpdateTeamRoleAsync(request.TeamRole);
        }
    }
}
