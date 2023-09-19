using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetAllTeams
{
    public class GetAllTeamsQuery : IRequest<IEnumerable<TeamDto>>
    {
    }
}
