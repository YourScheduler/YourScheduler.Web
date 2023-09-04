using Microsoft.AspNetCore.Identity;

namespace YourScheduler.Infrastructure.Entities;

public  class ApplicationUser : IdentityUser<int>
{
    public string Name { get; set; } = default!;

    public string Surname { get; set; } = default!;

    public string Displayname { get; set; } = default!;

    public ICollection<ApplicationUserEvents>? ApplicationUsersEvents { get; set; }

    public ICollection<ApplicationUserTeams>? ApplicationUsersTeams { get; set; }   
}
