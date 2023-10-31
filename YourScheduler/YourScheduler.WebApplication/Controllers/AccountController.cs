using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourScheduler.BusinessLogic.Commands.AuthorizeUser;
using YourScheduler.BusinessLogic.Commands.RegisterUser;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Queries.RefreshUser;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.CustomExceptions;
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
                throw new AuthorizationException("Invalid Email or Password");

            var response = await _mediator.Send(new AuthorizeUserCommand(model));

            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> SignIn([FromBody] RegisterUserDTO form)
        {
            if (form is null)
                return BadRequest("Invalid Register form model.");

            var response = await _mediator.Send(new RegisterUserCommand(form));

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("loadUser")]
        public async Task<IActionResult> LoadUser()
        {
           var response = await _mediator.Send(new RefreshUserQuery(User.FindFirst(ClaimTypes.Email).Value));
            return Ok(response);
        }
    }
}
