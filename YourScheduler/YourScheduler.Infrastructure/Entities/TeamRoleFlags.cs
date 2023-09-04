using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Entities
{
    public class TeamRoleFlags
    {
        public int TeamRoleId { get; set; }
        public bool CanRemoveTeamMember { get; set; } = false;
        public bool CanAddTeamMember { get; set; } = false;
        public bool CanAddTeamRole { get; set; } = false;
        public bool CanEditTeamRole { get; set; } = false;
        public bool CanRemoveTeamRole { get; set; } = false;
        public bool CanEditRoleFlags { get; set; } = false;
        public bool CanEditTeamPhoto { get; set; } = false;
        public bool CanEditDescription { get; set; } = false;
        public bool CanEditTeamMessage { get; set; } = false;
        public bool CanEditTeamName { get; set; } = false;
        public bool CanAddTeamEvent { get; set; } = false;
        public bool CanEditTeamEvent { get; set; } = false;
        public bool CanRemoveTeamEvent { get; set; } = false;
        public bool CanSendEmailToTeam { get;set; } = false;
    }
}
