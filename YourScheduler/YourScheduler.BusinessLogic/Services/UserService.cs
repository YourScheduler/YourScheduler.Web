﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Mappers;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.BusinessLogic.Services
{
    internal class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        private readonly UserMapper _mapper;
        public UserService(IUsersRepository usersRepository)
        {
            _mapper = new UserMapper();
            _usersRepository = usersRepository;
        }
        public List<UserDto> GetAllUsers()
        {
            List<UserDto> users = new List<UserDto>();  
            foreach (var item in _usersRepository.GetUsersFromDataBase())
            {
                UserDto user = new UserDto();

                user = _mapper.UserToUserDtoMapp(item);
                
                users.Add(user);    
               
            }

            return users;
        }

        public async Task<UserDto> GetUserById(string id)
        {
            var user=await _usersRepository.GetUserById(id);
            UserDto userDto = new UserDto();
            userDto=_mapper.UserToUserDtoMapp(user);
            return userDto;
        }

        public void UpdateUser(UserDto userDtoUpdated)
        {
            var user = _mapper.UserDtoToUserMap(userDtoUpdated);

            _usersRepository.UpdateUser(user);
        }

        public void AddUser(UserDto newUser)
        {
            var user = _mapper.UserDtoToUserMap(newUser);
            _usersRepository.AddUser(user);
        }

        public  UserDto GetUserByEmail(String email)
        {
            ApplicationUser application = new ApplicationUser();
           // application.Email = _mapper.UserDtoToUserMap(email);
            var user =  _usersRepository.GetUserByEmail(email);
           // UserDto userDto = new UserDto();
            var userDto = _mapper.UserToUserDtoMapp(user);
            return userDto;
        }


    

    }
}
