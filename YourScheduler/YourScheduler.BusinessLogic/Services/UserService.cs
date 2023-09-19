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
        //public List<ApplicationUserDto> GetAllUsers()
        //{

        //    //List<ApplicationUserDto> users = new List<ApplicationUserDto>();  
        //    //foreach (var item in _usersRepository.GetUsersFromDataBase())
        //    //{ 
        //    //    users.Add(_mapper.Map<ApplicationUserDto>(item));    
        //    //}

        //    return users;
        //}

        //public ApplicationUserDto GetUserById(int id)
        //{

        //    var user = _usersRepository.GetUserById(id);
        //    return _mapper.Map<ApplicationUserDto>(user);
        //}

        public void UpdateUser(ApplicationUserDto userDtoUpdated)
        {
            var user = _mapper.Map<ApplicationUser>(userDtoUpdated);

          //  _usersRepository.UpdateUser(user);
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
