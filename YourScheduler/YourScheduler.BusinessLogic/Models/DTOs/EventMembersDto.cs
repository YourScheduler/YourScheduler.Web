namespace YourScheduler.BusinessLogic.Models.DTOs
{
    public class EventMembersDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public bool Isopen { get; set; }

        public int administratorId { get; set; }

        public IEnumerable<ApplicationUserDto>? EventUsers { get; set; }
    }
}
