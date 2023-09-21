using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetUserByEmail
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, ApplicationUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUserByEmailHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<ApplicationUserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var retrievedUser = await _usersRepository.GetUserByEmailAsync(request.UserEmail);
            return _mapper.Map<ApplicationUserDto>(retrievedUser);
        }
    }
}
