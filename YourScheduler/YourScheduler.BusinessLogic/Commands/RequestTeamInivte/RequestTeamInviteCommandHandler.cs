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
            var user = await _usersRepository.GetUserByIdAsync(request.UserId);

            if (await _teamsRepository.VerifyIsTeamMemberAsync(request.UserId, request.TeamId))
            {
                throw new Exception("You have recently requested an invite or you are already a team member"); // do zmiany
            }
            
            var token = _jwtTokenGenerator.GenerateToken(request.UserId, request.TeamId);
            var link = $"https://localhost:7217/api/TeamMember/AcceptTeamInvitation?token={token}"; // change when endpoint is created
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

            var emailMessage = new Message(adminsEmails, $"User {user.Displayname} requested invite to your team on YourScheduler",
                "<p>YourScheduler<p>" +
                $"A user {user.Displayname} asked you to join your team: {team.Name}" +
                "If you wish to accept the request click I accept otherwise just ignore this message" +
                "<br>" +
                $"<a href={link}>I accept</a>");

            _emailService.SendEmail(emailMessage);
            await _teamMemberRepository.AddTeamMemberAsInvteeAsync(request.UserId, request.TeamId);

            return "User requested administrators to accept his invitation to the team";
        }
    }
}
