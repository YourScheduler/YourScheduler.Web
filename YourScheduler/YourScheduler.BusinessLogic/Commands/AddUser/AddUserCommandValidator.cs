using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddUser
{
    public class AddUserCommandValidator:AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IUsersRepository usersRepository)
        {
            RuleFor(c => c.UserDto.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have at least 2 characters")
             .MinimumLength(20).WithMessage("Name should have maximum of 20 characters");
            RuleFor(c => c.UserDto.Email).EmailAddress().WithMessage("Please enter email");
        }
    }
}
