using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;

[PrimaryKey("ApplicationUserId","TeamId")]
public  class ApplicationUserTeams
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = default!;

    public int TeamRoleId { get; set; }

    public TeamRole TeamRole { get; set; } = default!;

    public int TeamId { get; set; }
    public Team Team { get; set; } = default!;
}
