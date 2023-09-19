using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetTeamById
{
    public class GetTeamByIdQuery : IRequest<TeamDto>
    {
        public int Id { get; set; }
        public GetTeamByIdQuery(int id)
        {
            Id = id;
        }
    }
}
