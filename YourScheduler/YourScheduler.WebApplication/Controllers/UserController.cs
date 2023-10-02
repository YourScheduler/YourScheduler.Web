using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Commands.AddUser;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Queries.GetAllUsers;
using YourScheduler.Infrastructure.Repositories;

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
        [Authorize]
        [Route("AddUser")]
        public async Task<ApplicationUserDto> AddUserAsync([FromBody]ApplicationUserDto applicationUserDto)
        {
            return await _mediator.Send(new AddUserCommand(applicationUserDto));
        }

        [HttpGet]
        [Authorize]
        [Route("GetUsers")]
        public async Task<IEnumerable<ApplicationUserDto>> GetUsersAsync()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }


    }
}
