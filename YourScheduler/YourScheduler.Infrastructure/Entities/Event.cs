using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;

public class Event
{
    public int  EventId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool IsOpen { get; set; }
    public int AdministratorId { get; set; }
    ICollection<ApplicationUserEvents> ApplicationUsersEvents { get; set; }
    public string PicturePath { get; set; }
}
