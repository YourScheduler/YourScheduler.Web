using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Commands.AddTeamRole;
using YourScheduler.BusinessLogic.Queries.GetAllTeamRolesForTeam;
using YourScheduler.BusinessLogic.Queries.GetTeamRoleById;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [Route("getAllTeamRolesForTeam/{input}")]
        public async Task<IActionResult> GetAllTeamRolesForTeam([FromBody] int teamId)
        {
            var returnedTeamRoles = await _mediator.Send(new GetAllTeamRolesForTeamQuery(teamId));

            return Ok(returnedTeamRoles);
        }

        [HttpGet]
        [Authorize]
        [Route("GetTeamRoleById/{input}")]
        public async Task<IActionResult> GetTeamRoleById([FromBody] int teamRoleId)
        {
            var returnedRole = await _mediator.Send(new GetTeamRoleByIdQuery(teamRoleId));

            return Ok(returnedRole);
        }

        [HttpPut]
        [Authorize]
        [Route("CreateTeamRole")]
        public async Task<IActionResult> CreateTeamRole([FromBody] TeamRole teamRole)
        {
            var createdTeamRole = await _mediator.Send(new AddTeamRoleQuery(teamRole));

            return new ObjectResult(createdTeamRole) { StatusCode = StatusCodes.Status201Created };
        }


    }
}
