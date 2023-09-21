using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest<TeamDto>
    {
        public TeamDto TeamDto { get; }

        public CreateTeamCommand(TeamDto teamDto)
        {
            TeamDto = teamDto;
        }
    }
}
