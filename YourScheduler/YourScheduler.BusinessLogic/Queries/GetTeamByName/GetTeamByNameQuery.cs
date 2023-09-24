using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetTeamByName
{
    public class GetTeamByNameQuery : IRequest<IEnumerable<TeamDto>>
    {
        public string Input { get; }

        public GetTeamByNameQuery(string input)
        {
            Input = input;
        }
    }
}
