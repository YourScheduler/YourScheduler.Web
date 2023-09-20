using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetAllUsersQueryHandler(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllUsersQuery resquest, CancellationToken cancellationToken)
        {
            var usersEnumerable = await _usersRepository.GetUsersFromDataBaseQueryable().ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationUserDto>>(usersEnumerable);
        }
    }
}
