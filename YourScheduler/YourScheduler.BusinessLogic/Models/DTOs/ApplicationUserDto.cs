using Microsoft.AspNetCore.Identity;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class ApplicationUserDto : IdentityUser<int>
{

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Displayname { get; set; } = null!;

}
