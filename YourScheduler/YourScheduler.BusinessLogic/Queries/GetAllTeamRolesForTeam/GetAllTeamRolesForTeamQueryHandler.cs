using MediatR;
using Microsoft.EntityFrameworkCore;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetAllTeamRolesForTeam
{
    public class GetAllTeamRolesForTeamQueryHandler : IRequestHandler<GetAllTeamRolesForTeamQuery, IEnumerable<TeamRole>>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;

        public GetAllTeamRolesForTeamQueryHandler(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public async Task<IEnumerable<TeamRole>> Handle(GetAllTeamRolesForTeamQuery request, CancellationToken cancellationToken)
        {
            return await _teamRoleRepository.GetAllTeamRolesForTeamQueryable(request.TeamId).ToListAsync();
        }
    }
}
