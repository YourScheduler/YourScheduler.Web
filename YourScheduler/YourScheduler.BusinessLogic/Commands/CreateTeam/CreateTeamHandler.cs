using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.CreateTeam
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, TeamDto>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly ITeamRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public CreateTeamHandler(ITeamsRepository teamsRepository, IMapper mapper, ITeamRoleRepository roleRepository)
        {
            _mapper = mapper;
            _teamRepository = teamsRepository;
            _roleRepository = roleRepository;
        }

        public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = _mapper.Map<Team>(request.TeamDto);
            var addedTeam = await _teamRepository.AddTeamAsync(team);
            var addedTeamDto = _mapper.Map<TeamDto>(addedTeam);

            for (int i = 0; i < 2; i++)
            {
                var numberAddedRows = _roleRepository.GetNumberOfRows();
                var addedRole = await _roleRepository.GetTeamRoleByIdAsync(i+1);
                var addedRoleDto = _mapper.Map<TeamRoleDto>(addedRole);
                addedRoleDto.TeamId = addedTeamDto.TeamId;
                addedRoleDto.TeamRoleId=numberAddedRows+1;
                var roleToAdd = _mapper.Map<TeamRole>(addedRoleDto);
                await _roleRepository.AddTeamRoleAsync(roleToAdd);
            }           

            return addedTeamDto;
        }
    }
}
