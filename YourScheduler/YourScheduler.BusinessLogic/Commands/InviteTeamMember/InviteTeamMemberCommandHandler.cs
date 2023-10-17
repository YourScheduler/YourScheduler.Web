using MediatR;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.InviteTeamMember
{
    public class InviteTeamMemberCommandHandler : IRequestHandler<InviteTeamMemberCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailService _emailService;
        private readonly ITeamsRepository _teamsRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;

        public InviteTeamMemberCommandHandler(IUsersRepository usersRepository, IJwtTokenGenerator jwtTokenGenerator, IEmailService emailService, ITeamsRepository teamsRepository, ITeamRoleRepository teamRoleRepository, ITeamMemberRepository teamMemberRepository)
        {
            _usersRepository = usersRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailService = emailService;
            _teamsRepository = teamsRepository;
            _teamMemberRepository = teamMemberRepository;

        }

        public async Task Handle(InviteTeamMemberCommand request, CancellationToken cancellation)
        {
            var team = await _teamsRepository.GetTeamByIdAsync(request.TeamId);
            var teamWithUser = team.TeamMembers.FirstOrDefault(t => t.ApplicationUserId == request.UserId);
            var user = await _usersRepository.GetUserByIdAsync(request.UserId);

            if (teamWithUser is not null)
            {
                if (teamWithUser.TeamRole.TeamRoleFlags.TeamRoleFlagsId == 1)
                {
                    throw new Exception("User is already pending invite");
                }
                else
                {
                    throw new Exception("User is already a part of the team");
                }
            }
            await _teamMemberRepository.AddTeamMemberAsInvteeAsync(request.UserId, request.TeamId);

            var token = _jwtTokenGenerator.GenerateToken(request.UserId, request.TeamId);
            var link = $"endpointlink/api/TeamMember/AcceptInvite?token={token}"; // change when endpoint is created

            var emailMessage = new Message(new List<string>() { user.Email }, $"You have been invited to join {team.Name} team on YourScheduler",
                "<p>YourScheduler<p>" +
                "If you wish to accept the invitation click provided link" +
                $"<a href={link}>{link}</a>");

            _emailService.SendEmail(emailMessage);


        }

    }
}


        
