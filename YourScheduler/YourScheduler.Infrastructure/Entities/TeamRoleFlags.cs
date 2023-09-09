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

        public TeamRoleFlags(int teamRoleId, bool canRemoveTeamMember, bool canAddTeamMember, bool canAddTeamRole, bool canEditTeamRole, bool canRemoveTeamRole, bool canEditRoleFlags, bool canEditTeamPhoto, bool canEditDescription, bool canEditTeamMessage, bool canEditTeamName, bool canAddTeamEvent, bool canEditTeamEvent, bool canRemoveTeamEvent, bool canSendEmailToTeam)
        {
            TeamRoleId = teamRoleId;
            CanRemoveTeamMember = canRemoveTeamMember;
            CanAddTeamMember = canAddTeamMember;
            CanAddTeamRole = canAddTeamRole;
            CanEditTeamRole = canEditTeamRole;
            CanRemoveTeamRole = canRemoveTeamRole;
            CanEditRoleFlags = canEditRoleFlags;
            CanEditTeamPhoto = canEditTeamPhoto;
            CanEditDescription = canEditDescription;
            CanEditTeamMessage = canEditTeamMessage;
            CanEditTeamName = canEditTeamName;
            CanAddTeamEvent = canAddTeamEvent;
            CanEditTeamEvent = canEditTeamEvent;
            CanRemoveTeamEvent = canRemoveTeamEvent;
            CanSendEmailToTeam = canSendEmailToTeam;
        }
    }
   
}
