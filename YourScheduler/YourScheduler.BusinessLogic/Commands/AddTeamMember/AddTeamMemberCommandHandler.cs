using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddTeamMember
{
    public class AddTeamMemberCommandHandler : IRequestHandler<AddTeamMemberCommand>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamsRepository _teamsRepository;
        private readonly IUsersRepository _usersRepository;

        public AddTeamMemberCommandHandler(ITeamMemberRepository teamMemberRepository, ITeamsRepository teamsRepository, IUsersRepository usersRepository)
        {
            _teamsRepository = teamsRepository;
            _teamMemberRepository = teamMemberRepository;
            _usersRepository = usersRepository;
        }

        public async Task Handle(AddTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamsRepository.GetTeamByIdAsync(request.TeamId);
            if (team.IsPrivate)
            {
                var userEmail = _usersRepository.GetUserByIdAsync(request.UserId);
                var token = 
                var message = new Message()
            }
            await _teamMemberRepository.AddTeamMemberAsync(request.UserId, request.TeamId);
        }
    }
}
