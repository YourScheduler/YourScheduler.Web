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
            List<TeamRoleDto> teamRoleDtos = new List<TeamRoleDto>();

            var teamRoleDto1 = new TeamRoleDto
            {
                TeamId = addedTeam.TeamId,
                Name = "Invitee",
                TeamRoleFlagsId = 1,
            };
            teamRoleDtos.Add(teamRoleDto1);

            var teamRoleDto2 = new TeamRoleDto
            {
                TeamId = addedTeam.TeamId,
                Name = "Admin",
                TeamRoleFlagsId = 2
            };
            teamRoleDtos.Add(teamRoleDto2);

            var teamRoleDto3 = new TeamRoleDto
            {
                TeamId = addedTeam.TeamId,
                Name = "User",
                TeamRoleFlagsId = 3
            };
            teamRoleDtos.Add(teamRoleDto3);

            foreach (var teamRoleDto in teamRoleDtos)
            {
                var teamRole = _mapper.Map<TeamRole>(teamRoleDto);
                await _roleRepository.AddTeamRoleAsync(teamRole);
            }
            return addedTeamDto;
        }
    }
}
