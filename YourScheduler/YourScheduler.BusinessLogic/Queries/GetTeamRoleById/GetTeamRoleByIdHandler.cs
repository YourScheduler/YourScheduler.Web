using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Queries.GetTeamRoleById
{
    public class GetTeamRoleByIdHandler : IRequestHandler<GetTeamRoleByIdQuery, TeamRole>
    {
        private readonly TeamRoleRepository _teamRoleRepository;

        public GetTeamRoleByIdHandler(TeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }
        public async Task<TeamRole> Handle(GetTeamRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.GetTeamRoleByIdAsync(request.TeamRoleId);
        }
    }
}
