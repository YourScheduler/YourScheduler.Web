using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<ApplicationUserDto>
    {
        public string UserEmail { get;}

        public GetUserByEmailQuery(string userEmail)
        {
            UserEmail = userEmail;
        }
    }
}
