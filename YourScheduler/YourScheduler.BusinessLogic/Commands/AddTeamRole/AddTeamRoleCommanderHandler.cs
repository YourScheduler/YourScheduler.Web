using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleCommnandHandler : IRequestHandler<AddTeamRoleCommand, TeamRole>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;

        public AddTeamRoleCommnandHandler(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task<TeamRole> Handle(AddTeamRoleCommand request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.AddTeamRoleAsync(request.TeamRole);
        }
    }
}
