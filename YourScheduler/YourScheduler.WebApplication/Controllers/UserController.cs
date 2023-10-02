using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Commands.AddUser;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Queries.GetAllUsers;
using YourScheduler.BusinessLogic.Queries.GetUserByEmail;
using YourScheduler.BusinessLogic.Queries.GetUserById;

namespace YourScheduler.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        [Route("AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody]ApplicationUserDto applicationUserDto)
        {
            var returnedUser = await _mediator.Send(new AddUserCommand(applicationUserDto));
            return new ObjectResult(returnedUser) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        //[Authorize]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var returnedUsers = await _mediator.Send(new GetAllUsersQuery());
            return Ok(returnedUsers);
        }

        [HttpGet]
        //[Authorize]
        [Route("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var returnedUser = await _mediator.Send(new GetUserByIdQuery(userId));
            return Ok(returnedUser);
        }

        [HttpGet]
        //[Authorize]
        [Route("GetUserByEmail/{userEmail}")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            var returnedUser = await _mediator.Send(new GetUserByEmailQuery(userEmail));
            return Ok(returnedUser);
        }

    }
}
