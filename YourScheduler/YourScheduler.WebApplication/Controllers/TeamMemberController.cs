﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security.Notifications;
using YourScheduler.BusinessLogic.Commands.AddTeamMember;
using YourScheduler.BusinessLogic.Commands.RemoveTeamMember;
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
        [Authorize]
        [Route("AddTeamMember")]
        public async Task<IActionResult> AddTeamMember(int userId, int teamRoleId, int teamId)
        {
            await _mediator.Send(new AddTeamMemberCommand(userId, teamRoleId, teamId));
            return NoContent();
        }
        [HttpDelete]
        [Authorize]
        [Route("RemoveTeamMember")]
        public async Task<IActionResult> RemoveTeamMember(int userId, int teamId)
        {
            try
            {
                await _mediator.Send(new RemoveTeamMemberCommand(userId, teamId));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpPut]
        [Authorize]
        [Route("UpdateTeamMemberRole")]
        public async Task<IActionResult> UpdateTeamMemberRole(int userId, int teamRoleId, int teamId)
        {
            await _mediator.Send(new UpdateTeamMemberRoleCommand(userId, teamRoleId, teamId));
            return NoContent();
        }

        
    }
}
