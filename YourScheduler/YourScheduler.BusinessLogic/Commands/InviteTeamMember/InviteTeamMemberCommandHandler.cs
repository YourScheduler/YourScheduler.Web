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
            var user = await _usersRepository.GetUserByIdAsync(request.UserId);

            if (await _teamsRepository.VerifyIsTeamMemberAsync(request.UserId, request.TeamId))
            {
                throw new Exception("User is already a part of the team or is pending invite");
            }

            var token = _jwtTokenGenerator.GenerateToken(request.UserId, request.TeamId);
            var link = $"https://localhost:7217/api/TeamMember/AcceptTeamInvitation?token={token}"; // change when endpoint is created

            var emailMessage = new Message(new List<string>() { user.Email }, $"You have been invited to join a team on YourScheduler",
                "<p>YourScheduler<p>" +
                $"You have received an invitation to join {team.Name}" +
                "If you wish to accept the invitation click I accept" +
                "<br>" +
                $"<a href={link}>I accept</a>");

            _emailService.SendEmail(emailMessage);

            await _teamMemberRepository.AddTeamMemberAsInvteeAsync(request.UserId, request.TeamId);


        }

    }
}


        
