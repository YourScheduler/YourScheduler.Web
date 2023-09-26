using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ApplicationUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public AddUserCommandHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<ApplicationUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var remappedUser = _mapper.Map<ApplicationUser>(request.UserDto);
            var addedUser = await _usersRepository.AddUserAsync(remappedUser);

            return _mapper.Map<ApplicationUserDto>(addedUser);
                
        }
    }
}
