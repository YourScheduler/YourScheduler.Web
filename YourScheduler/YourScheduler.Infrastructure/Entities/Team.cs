using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;
public  class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Creator { get; set; } = default!; 
    public string? Message { get; set; }
    public ICollection<ApplicationUserTeams>? TeamMember { get; set; }
    public ICollection<TeamRole> TeamRoles { get; set; } = default!;
    public string? PicturePath { get; set; }

}
