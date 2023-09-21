using AutoMapper;
using MediatR;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserDto>
    {
        private readonly IMapper _mapper;
        private readonly UsersRepository _usersRepository;

        public GetUserByIdQueryHandler(IMapper mapper, UsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<ApplicationUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var retrievedUser = await _usersRepository.GetUserByIdAsync(request.UserId);
            return _mapper.Map<ApplicationUserDto>(retrievedUser);
        }
    }
}
