using MediatR;
using Microsoft.AspNetCore.Identity;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public RegisterUserDTO RegisterUserDTO { get; }

        public RegisterUserCommand(RegisterUserDTO form)
        {
            RegisterUserDTO = form;
        }
    }
}
