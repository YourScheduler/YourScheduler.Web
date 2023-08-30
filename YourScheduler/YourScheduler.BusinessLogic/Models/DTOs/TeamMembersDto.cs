namespace YourScheduler.BusinessLogic.Models.DTOs
{
    public class TeamMembersDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ApplicationUserDto> TeamUsers { get; set; }
    }
}
