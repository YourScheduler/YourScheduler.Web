namespace YourScheduler.Infrastructure.Entities;
public  class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public int AdministratorId { get; set; }
    ICollection<ApplicationUserTeams> ApplicationUsersTeams { get; set; }
    public string PicturePath { get; set; }

}
