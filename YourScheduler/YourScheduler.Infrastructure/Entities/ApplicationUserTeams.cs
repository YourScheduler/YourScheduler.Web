using Microsoft.EntityFrameworkCore;

namespace YourScheduler.Infrastructure.Entities;

[PrimaryKey("ApplicationUserId","TeamId","TeamRoleId")]
public  class ApplicationUserTeams
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = default!;
    public int TeamRoleId { get; set; }

    public TeamRole TeamRole { get; set; } = default!;

    public int TeamId { get; set; }
    public Team Team { get; set; } = default!;
}
