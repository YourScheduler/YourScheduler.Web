using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Commands.AuthorizeUser;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> SignIn([FromBody] AuthorizationRequest model)
        {
            if(model is null)
                return BadRequest("Invalid Email or Password");

            var response = await _mediator.Send(new AuthorizeUserCommand(model));

            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> SignIn([FromBody] RegisterUserDTO model)
        {
            if (model is null)
                return BadRequest("Invalid Email or Password");

            var response = await _mediator.Send(new AuthorizeUserCommand(model));

            return Ok(response);
        }


        [Authorize]
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("loadUser")]
        public async Task<IActionResult> LoadUser()
        {
           // var user = await _userManager.GetUserAsync(User);
            return Ok();
        }
    }
}
