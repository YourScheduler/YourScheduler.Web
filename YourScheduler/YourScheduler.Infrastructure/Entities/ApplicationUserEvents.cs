using Microsoft.EntityFrameworkCore;

namespace YourScheduler.Infrastructure.Entities;

[PrimaryKey("ApplicationUserId", "EventId")]
public  class ApplicationUserEvents
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }
}
