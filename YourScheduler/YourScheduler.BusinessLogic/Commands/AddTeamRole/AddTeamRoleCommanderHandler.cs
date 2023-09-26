using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleCommnandHandler : IRequestHandler<AddTeamRoleCommand, TeamRoleDto>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;
        private readonly IMapper _mapper;

        public AddTeamRoleCommnandHandler(ITeamRoleRepository teamRoleRepository, IMapper mapper)
        {
            _teamRoleRepository = teamRoleRepository;
            _mapper = mapper;
        }

        public async Task<TeamRoleDto> Handle(AddTeamRoleCommand request, CancellationToken cancellationToken)
        {
            var mappedDto = _mapper.Map<TeamRole>(request);
            var addedRole = await _teamRoleRepository.AddTeamRoleAsync(mappedDto);
            return _mapper.Map<TeamRoleDto>(addedRole);
        }
    }
}
