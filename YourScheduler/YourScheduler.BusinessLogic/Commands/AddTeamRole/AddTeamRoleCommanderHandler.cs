using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleCommnandHandler : IRequestHandler<AddTeamRoleCommand, TeamRole>
    {
        private readonly TeamRoleRepository _teamRoleRepository;

        public AddTeamRoleCommnandHandler(TeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task<TeamRole> Handle(AddTeamRoleCommand request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.AddTeamRoleAsync(request.TeamRole);
        }
    }
}
