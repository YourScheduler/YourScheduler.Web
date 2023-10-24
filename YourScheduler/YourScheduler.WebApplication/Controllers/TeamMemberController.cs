using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Commands.AcceptTeamInvitation;
using YourScheduler.BusinessLogic.Commands.AddTeamMember;
using YourScheduler.BusinessLogic.Commands.InviteTeamMember;
using YourScheduler.BusinessLogic.Commands.RemoveTeamMember;
using YourScheduler.BusinessLogic.Commands.RequestTeamInivte;
using YourScheduler.BusinessLogic.Commands.UpdateTeamMemberRole;

namespace YourScheduler.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        [Route("AddTeamMember")]
        public async Task<IActionResult> AddTeamMember(int userId, int teamId)
        {
            var response = await _mediator.Send(new AddTeamMemberCommand(userId, teamId));
            return Ok(response);
        }

        [HttpDelete]
        //[Authorize]
        [Route("RemoveTeamMember")]
        public async Task<IActionResult> RemoveTeamMember(int userId, int teamId)
        {

            await _mediator.Send(new RemoveTeamMemberCommand(userId, teamId));
            return Ok();
        }
        [HttpPut]
        //[Authorize]
        [Route("UpdateTeamMemberRole")]
        public async Task<IActionResult> UpdateTeamMemberRole(int userId, int teamRoleId, int teamId)
        {

            await _mediator.Send(new UpdateTeamMemberRoleCommand(userId, teamRoleId, teamId));
            return NoContent();

        }

        [HttpPost]
        //[Authorize]
        [Route("InviteTeamMemberToTeam")]
        public async Task<IActionResult> InviteTeamMemberToTeam(int userId, int teamId)
        {

            await _mediator.Send(new InviteTeamMemberCommand(userId, teamId));
            return Ok();
        }
        [HttpPost]
        //[Authorize]
        [Route("RequestInviteToTeam")]
        public async Task<IActionResult> RequestInviteToTeam(int userId, int teamId)
        {

            var response = await _mediator.Send(new RequestTeamInviteCommand(userId, teamId));
            return Ok(response);

        }
        [HttpPut]
        //[Authorize]
        [Route("AcceptTeamInvitation")]
        public async Task<IActionResult> AcceptTeamInvitation(string token)
        {

            var respone = await _mediator.Send(new AcceptTeamInvitationCommand(token));
            return Ok(respone);

        }
    }
}
