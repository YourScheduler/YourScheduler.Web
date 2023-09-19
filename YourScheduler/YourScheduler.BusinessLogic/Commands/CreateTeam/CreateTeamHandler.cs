using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.CreateTeam
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, TeamDto>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
        public CreateTeamHandler(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamsRepository;
        }

        public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var Team = _mapper.Map<Infrastructure.Entities.Team>(request.TeamDto);
            var addedTeam = await _teamRepository.AddTeamAsync(Team);

            return _mapper.Map<TeamDto>(addedTeam);
        }
    }
}
