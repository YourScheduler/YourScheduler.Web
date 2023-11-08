using MediatR;
using Microsoft.AspNetCore.Identity;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.CustomExceptions;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,IdentityResult>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtGenerator;

        public RegisterUserCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.RegisterUserDTO.Password != request.RegisterUserDTO.ConfirmPassword)
                throw new RegisterException("Password Mismatch");

            if (await _userManager.FindByEmailAsync(request.RegisterUserDTO.Email) != null)
                throw new RegisterException("Email already registered");

            var user = new ApplicationUser {
                Email = request.RegisterUserDTO.Email,
                UserName = request.RegisterUserDTO.Email,
                Displayname = request.RegisterUserDTO.DisplayName
            };

            var result = await _userManager.CreateAsync(user, request.RegisterUserDTO.Password);

            if (!result.Succeeded)
                throw new RegisterException("Application error.");

            return result;
        }
    }
}
