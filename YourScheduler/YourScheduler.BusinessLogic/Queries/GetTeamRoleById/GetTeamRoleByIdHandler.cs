using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetTeamRoleById
{
    public class GetTeamRoleByIdHandler : IRequestHandler<GetTeamRoleByIdQuery, TeamRoleDto>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;
        private readonly IMapper _mapper;

        public GetTeamRoleByIdHandler(ITeamRoleRepository teamRoleRepository, IMapper mapper)
        {
            _teamRoleRepository = teamRoleRepository;
            _mapper = mapper;
        }
        public async Task<TeamRoleDto> Handle(GetTeamRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var teamRoleReturned = await _teamRoleRepository.GetTeamRoleByIdAsync(request.TeamRoleId);
            return _mapper.Map<TeamRoleDto>(teamRoleReturned);
        }
    }
}
