using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Models.DTOs
{
    public class TeamRoleDto
    {
        public int TeamRoleId { get; set; }

        public int TeamId { get; set; }

        public string Name { get; set; } = default!;

        public TeamRoleFlags TeamRoleFlags { get; set; } = default!;
    }
}
