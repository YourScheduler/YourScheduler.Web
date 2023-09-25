using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.BusinessLogic.Commands.RemoveTeamRoleById
{
    public class RemoveTeamRoleByIdCommand : IRequest
    {
        public int TeamRoleId { get; }

        public RemoveTeamRoleByIdCommand(int teamRoleId)
        {
            TeamRoleId = teamRoleId;
        }
    }
}
