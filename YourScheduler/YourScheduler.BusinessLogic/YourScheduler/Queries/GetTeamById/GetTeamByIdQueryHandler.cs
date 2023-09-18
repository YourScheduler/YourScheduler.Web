using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.YourScheduler.Queries.GetAllTeams;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.YourScheduler.Queries.GetTeamById
{
    public class GetTeamByIdQueryHandler: IRequestHandler<GetTeamByIdQuery, TeamDto>
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
