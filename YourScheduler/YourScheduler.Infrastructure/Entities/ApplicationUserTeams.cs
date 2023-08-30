using Microsoft.EntityFrameworkCore;

namespace YourScheduler.Infrastructure.Entities;

[PrimaryKey("ApplicationUserId","TeamId")]
public  class ApplicationUserTeams
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
}
