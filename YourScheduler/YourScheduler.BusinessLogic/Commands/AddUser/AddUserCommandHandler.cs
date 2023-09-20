using AutoMapper;
using MediatR;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ApplicationUser>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public AddUserCommandHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<ApplicationUser> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var remappedUser = _mapper.Map<ApplicationUser>(request.UserDto);
            return await _usersRepository.AddUserAsync(remappedUser);
        }
    }
}
