﻿namespace YourScheduler.Infrastructure.Entities;
public  class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Creator { get; set; } = default!; 
    public string? Message { get; set; }
    public bool IsPrivate { get; set; } = default!;
    public ICollection<ApplicationUserTeams> TeamMembers { get; set; } = default!;
    public ICollection<TeamRole> TeamRoles { get; set; } = default!;
    public string? PicturePath { get; set; }

}
