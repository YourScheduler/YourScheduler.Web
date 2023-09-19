using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetTeamById
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamDto>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetTeamByIdQueryHandler(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _teamRepository = teamsRepository;
            _mapper = mapper;

        }

        public async Task<TeamDto> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetTeamByIdAsync(request.Id);
            var teamDto = _mapper.Map<TeamDto>(team);
            return teamDto;
        }
    }


}
