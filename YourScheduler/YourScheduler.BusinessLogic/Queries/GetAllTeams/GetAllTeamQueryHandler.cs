using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetAllTeams
{
    public class GetAllTeamQueryHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<TeamDto>>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetAllTeamQueryHandler(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamRepository = teamsRepository;
        }
        public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllExistedTeamsQueryable().ToListAsync();
            var teamsDtos = _mapper.Map<IEnumerable<TeamDto>>(teams);
            return teamsDtos;
        }
    }
}
