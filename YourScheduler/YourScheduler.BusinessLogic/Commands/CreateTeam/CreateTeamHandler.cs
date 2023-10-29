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
            TeamRoleDto teamRoleDto = new TeamRoleDto();
            teamRoleDto.TeamRoleFlags = new TeamRoleFlags();
            teamRoleDto.TeamRoleFlags.CanSendEmailToTeam = true;
            teamRoleDto.TeamRoleFlags.CanEditTeamName = true;
            teamRoleDto.TeamRoleFlags.CanAddTeamEvent = true;
            teamRoleDto.TeamRoleFlags.CanEditTeamPhoto = true;
            teamRoleDto.TeamRoleFlags.CanRemoveTeamMember = true;
            teamRoleDto.TeamRoleFlags.CanEditDescription = true;
            teamRoleDto.TeamRoleFlags.CanRemoveTeamRole = true;
            teamRoleDto.TeamRoleFlags.CanEditTeamRole = true;
            teamRoleDto.TeamRoleFlags.CanAddTeamRole = true;
            teamRoleDto.TeamRoleFlags.CanAddTeamEvent = true;
            teamRoleDto.TeamRoleFlags.CanAddTeamMember = true;
            teamRoleDto.TeamRoleFlags.CanRemoveTeamEvent = true;
            teamRoleDto.TeamRoleFlags.CanEditRoleFlags = true;
            teamRoleDto.TeamRoleFlags.CanEditTeamMessage = true;
            teamRoleDto.Name =addedTeamDto.Name+"adminrole";
            teamRoleDto.TeamId =addedTeamDto.TeamId;   
            var teamRole = _mapper.Map<TeamRole>(teamRoleDto);
            await _roleRepository.AddTeamRoleAsync(teamRole);
            return addedTeamDto;
        }
    }
}
