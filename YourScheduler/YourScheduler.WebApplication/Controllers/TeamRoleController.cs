using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Queries.GetAllTeamRolesForTeam;

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
        public async Task<IActionResult> GetAllTeamRolesForTeam([FromBody]int teamId)
        {
            var returnedTeamRoles = await _mediator.Send(new GetAllTeamRolesForTeamQuery(teamId));
            return Ok(returnedTeamRoles);
        }


    }
}
