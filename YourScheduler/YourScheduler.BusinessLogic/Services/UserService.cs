using AutoMapper;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;



namespace YourScheduler.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

 
        public UserService(IUsersRepository usersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            
        }

        //public void AddUser(ApplicationUserDto newUser)
        //{
        //    var user = _mapper.Map<ApplicationUser>(newUser);
        //    _usersRepository.AddUser(user);
        //}

        //public  ApplicationUserDto GetUserByEmail(String email)
        //{
        //    var user = _usersRepository.GetUserByEmail(email);

        //    var mappedUser = _mapper.Map<ApplicationUserDto>(user);


        //    return mappedUser;
        //}

    }
}
