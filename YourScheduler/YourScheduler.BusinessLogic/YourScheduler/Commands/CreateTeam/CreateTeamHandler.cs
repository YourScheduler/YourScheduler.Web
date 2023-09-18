using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.YourScheduler.Commands.CreateCarWorkshop;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.YourScheduler.Commands.CreateTeam
{
    public class CreateTeamHandler:IRequestHandler<CreateTeamCommand>
    {
        private readonly ITeamsRepository _teamRepository;
        private readonly IMapper _mapper;
       public CreateTeamHandler(ITeamsRepository teamsRepository, IMapper mapper) 
       { 
            _mapper = mapper;
            _teamRepository = teamsRepository;          
       }

        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var Team = _mapper.Map<Infrastructure.Entities.Team>(request);
            await _teamRepository.AddTeamAsync(Team);
           
            var allTeams=await _teamRepository.GetAllExistedTeamsQueryable();
            var lastAddedTeamId = allTeams.Last().TeamId;
            return Unit.Value;
        }
    }
}
