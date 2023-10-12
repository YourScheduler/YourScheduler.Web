using System.ComponentModel.DataAnnotations;

namespace YourScheduler.Infrastructure.Entities
{
    public class TeamRoleFlags
    {
        [Key]
        public int TeamRoleFlagsId { get; set; }
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
        public bool CanSendEmailToTeam { get; set; } = false;
        public bool CanViewContent { get; set; } = false;

        public override bool Equals(object? obj)
        {
            if (obj is TeamRoleFlags other)
            {
                return CanRemoveTeamMember == other.CanRemoveTeamMember &&
                       CanAddTeamMember == other.CanAddTeamMember &&
                       CanAddTeamRole == other.CanAddTeamRole &&
                       CanEditTeamRole == other.CanEditTeamRole &&
                       CanRemoveTeamRole == other.CanRemoveTeamRole &&
                       CanEditRoleFlags == other.CanEditRoleFlags &&
                       CanEditTeamPhoto == other.CanEditTeamPhoto &&
                       CanEditDescription == other.CanEditDescription &&
                       CanEditTeamMessage == other.CanEditTeamMessage &&
                       CanEditTeamName == other.CanEditTeamName &&
                       CanAddTeamEvent == other.CanAddTeamEvent &&
                       CanEditTeamEvent == other.CanEditTeamEvent &&
                       CanRemoveTeamEvent == other.CanRemoveTeamEvent &&
                       CanSendEmailToTeam == other.CanSendEmailToTeam &&
                       CanViewContent == other.CanViewContent;
            }
            return false;
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(CanRemoveTeamMember);
            hash.Add(CanAddTeamMember);
            hash.Add(CanAddTeamRole);
            hash.Add(CanEditTeamRole);
            hash.Add(CanRemoveTeamRole);
            hash.Add(CanEditRoleFlags);
            hash.Add(CanEditTeamPhoto);
            hash.Add(CanEditDescription);
            hash.Add(CanEditTeamMessage);
            hash.Add(CanEditTeamName);
            hash.Add(CanAddTeamEvent);
            hash.Add(CanEditTeamEvent);
            hash.Add(CanRemoveTeamEvent);
            hash.Add(CanSendEmailToTeam);
            hash.Add(CanViewContent);
            return hash.ToHashCode();
        }
    }        
}
