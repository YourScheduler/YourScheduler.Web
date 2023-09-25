using MediatR;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Commands.AddTeamRole
{
    public class AddTeamRoleQuery : IRequest<TeamRole>
    {
        public TeamRole TeamRole { get; set; }

        public AddTeamRoleQuery(TeamRole teamRole)
        {
            TeamRole = teamRole;
        }
    }
}
