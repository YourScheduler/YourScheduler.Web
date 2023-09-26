using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommandHandler : IRequestHandler<UpdateTeamRoleCommand, TeamRole>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;

        public UpdateTeamRoleCommandHandler(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task<TeamRole> Handle(UpdateTeamRoleCommand request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.UpdateTeamRoleAsync(request.TeamRole);
        }
    }
}
