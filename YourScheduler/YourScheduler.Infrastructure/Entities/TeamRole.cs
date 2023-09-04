using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Entities
{
    public class TeamRole
    {
        public int TeamRoleId { get; set; }

        public string Name { get; set; } = default!;

        public TeamRoleFlags TeamRoleFlags { get; set; } = default!;

        public ICollection<ApplicationUserTeams>? ApplicationUserTeams { get; set; }

    }
}
