using Microsoft.AspNetCore.Identity;

namespace YourScheduler.Infrastructure.Entities;

public  class ApplicationUser : IdentityUser<int>
{
    public string Name { get; set; } 

    public string Surname { get; set; } 

    public string Displayname { get; set; }

    public ICollection<ApplicationUserEvents> ApplicationUsersEvents { get; set; }

    public ICollection<ApplicationUserTeams> ApplicationUsersTeams { get; set; }   
}
