using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleQueryHandler : IRequestHandler<AddTeamRoleQuery, TeamRole>
    {
        private readonly TeamRoleRepository _teamRoleRepository;

        public AddTeamRoleQueryHandler(TeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task<TeamRole> Handle(AddTeamRoleQuery request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.AddTeamRoleAsync(request.TeamRole);
        }
    }
}
