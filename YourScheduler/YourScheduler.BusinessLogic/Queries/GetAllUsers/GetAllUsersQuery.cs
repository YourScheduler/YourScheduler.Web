using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {
    }
}
