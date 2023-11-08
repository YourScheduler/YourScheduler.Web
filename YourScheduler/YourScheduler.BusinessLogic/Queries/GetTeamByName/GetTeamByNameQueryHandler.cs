using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Extension;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetTeamByName
{
    public class GetTeamByNameQueryHandler : IRequestHandler<GetTeamByNameQuery, IEnumerable<TeamDto>>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetTeamByNameQueryHandler(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _teamRepository = teamsRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<TeamDto>> Handle(GetTeamByNameQuery request, CancellationToken cancellationToken)
        {
            var teams = _teamRepository.GetAllExistedTeamsQueryable();
            var teamsNames = await teams
                .Select(t => t.Name)
                .ToListAsync();

            var matchingNames = teamsNames.SearchByInput(request.Input);

            var results = await teams.Where(t => matchingNames.Contains(t.Name))
                .ToListAsync();

            return _mapper.Map<IEnumerable<TeamDto>>(results);
               
        }
    }
}
