using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Commands.AddUser
{
    public class AddUserCommand : IRequest<ApplicationUserDto>
    {
        public ApplicationUserDto UserDto { get; }

        public AddUserCommand(ApplicationUserDto userDto)
        {
            UserDto = userDto;
        }
    }

}
