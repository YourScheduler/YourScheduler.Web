using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetTeamById
{
    public class GetTeamByIdQuery : IRequest<TeamDto>
    {
        public int Id { get;}
        public GetTeamByIdQuery(int id)
        {
            Id = id;
        }
    }
}
