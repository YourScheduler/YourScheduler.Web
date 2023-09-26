using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetAllTeamRolesForTeam
{
    public class GetAllTeamRolesForTeamQueryHandler : IRequestHandler<GetAllTeamRolesForTeamQuery, IEnumerable<TeamRoleDto>>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;
        private readonly IMapper _mapper;

        public GetAllTeamRolesForTeamQueryHandler(ITeamRoleRepository teamRoleRepository, IMapper mapper)
        {
            _teamRoleRepository = teamRoleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamRoleDto>> Handle(GetAllTeamRolesForTeamQuery request, CancellationToken cancellationToken)
        {
            var returnedTeamRoles = await _teamRoleRepository.GetAllTeamRolesForTeamQueryable(request.TeamId).ToListAsync();
            return _mapper.Map<IEnumerable<TeamRoleDto>>(returnedTeamRoles);
        }
    }
}
