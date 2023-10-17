using MediatR;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.RequestTeamInivte
{
    public class RequestTeamInviteCommandHandler : IRequestHandler<RequestTeamInviteCommand, string>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailService _emailService;
        private readonly ITeamsRepository _teamsRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamRoleRepository _teamRoleRepository;

        public RequestTeamInviteCommandHandler(IUsersRepository usersRepository, IJwtTokenGenerator jwtTokenGenerator, IEmailService emailService, ITeamsRepository teamsRepository, ITeamMemberRepository teamMemberRepository, ITeamRoleRepository teamRoleRepository)
        {
            _usersRepository = usersRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailService = emailService;
            _teamsRepository = teamsRepository;
            _teamMemberRepository = teamMemberRepository;
            _teamRoleRepository = teamRoleRepository;

        }

        public async Task<string> Handle(RequestTeamInviteCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamsRepository.GetTeamByIdAsync(request.TeamId);
            var teamWithUser = team.TeamMembers.FirstOrDefault(t => t.ApplicationUserId == request.UserId);
            var user = await _usersRepository.GetUserByIdAsync(request.UserId);

            if (teamWithUser is not null)
            {
                if (teamWithUser.TeamRole.TeamRoleFlags.TeamRoleFlagsId == 1)
                {
                    throw new Exception("Your previous invite request is still pending");
                }
                else
                {
                    throw new Exception("You are already a part of the team!");
                }
            }
            await _teamMemberRepository.AddTeamMemberAsInvteeAsync(request.UserId, request.TeamId);

            var token = _jwtTokenGenerator.GenerateToken(request.UserId, request.TeamId);
            var link = $"endpointlink/api/TeamMember/AcceptInvite?token={token}"; // change when endpoint is created
            var allTeamRoles = _teamRoleRepository.GetAllTeamRolesForTeamQueryable(request.TeamId).ToList();

            var allTeamRolesWithInviteFlag = new List<TeamRole>();
            var adminsEmails = new List<string>();

            foreach (var teamRole in allTeamRoles)
            {
                if (teamRole.TeamRoleFlags.CanAddTeamMember == true)
                {
                    allTeamRolesWithInviteFlag.Add(teamRole);
                }
            }

            foreach (var teamMember in team.TeamMembers)
            {
                if (allTeamRolesWithInviteFlag.Contains(teamMember.TeamRole))
                {
                    if(teamMember.ApplicationUser.Email is not null)
                    {
                        adminsEmails.Add(teamMember.ApplicationUser.Email);
                    }
                }
            }

            var emailMessage = new Message(adminsEmails, $"User {user.Displayname} requested invite to the {team.Name} on YourScheduler",
                "<p>YourScheduler<p>" +
                "If you wish to accept the request click provided link" +
                $"<a href={link}>{link}</a>");

            _emailService.SendEmail(emailMessage);

            return "User requested administrators to accept his invitation to the team";
        }
    }
}
