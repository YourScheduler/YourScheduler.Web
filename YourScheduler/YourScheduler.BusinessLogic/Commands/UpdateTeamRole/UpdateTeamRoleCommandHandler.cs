using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
    public class UpdateTeamRoleCommandHandler : IRequestHandler<UpdateTeamRoleCommand, TeamRoleDto>
    {
        private readonly ITeamRoleRepository _teamRoleRepository;
        private readonly IMapper _mapper;

        public UpdateTeamRoleCommandHandler(ITeamRoleRepository teamRoleRepository, IMapper mapper)
        {
            _teamRoleRepository = teamRoleRepository;
            _mapper = mapper;
        }

        public async Task<TeamRoleDto> Handle(UpdateTeamRoleCommand request, CancellationToken cancellationToken)
        {
            var returnedTeamRole = await _teamRoleRepository.UpdateTeamRoleAsync(request.TeamRole);
            return _mapper.Map<TeamRoleDto>(returnedTeamRole);
        }
    }
}
