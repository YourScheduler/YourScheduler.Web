using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetTeamRoleById
{
    public class GetTeamRoleByIdHandler : IRequestHandler<GetTeamRoleByIdQuery, TeamRole>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;

        public GetTeamRoleByIdHandler(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }
        public async Task<TeamRole> Handle(GetTeamRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.GetTeamRoleByIdAsync(request.TeamRoleId);
        }
    }
}
