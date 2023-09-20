using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.AddUser
{
    public class AddUserCommand : IRequest<ApplicationUser>
    {
        public ApplicationUserDto UserDto { get; }

        public AddUserCommand(ApplicationUserDto userDto)
        {
            UserDto = userDto;
        }
    }

}
