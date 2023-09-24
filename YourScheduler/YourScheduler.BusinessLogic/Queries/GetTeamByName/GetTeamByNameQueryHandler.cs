using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetTeamByName
{
    public class GetTeamByNameQueryHandler : IRequestHandler<GetTeamByNameQuery, TeamDto>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
        public GetTeamByNameQueryHandler(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _teamRepository = teamsRepository;
            _mapper = mapper;

        }
        public Task<TeamDto> Handle(GetTeamByNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
