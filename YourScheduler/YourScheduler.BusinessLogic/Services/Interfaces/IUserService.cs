using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
      //  List<ApplicationUserDto> GetAllUsers();

        //ApplicationUserDto GetUserByEmail(string email);

       // void AddUser(ApplicationUserDto user);
      //  ApplicationUserDto GetUserById(int id);
        void UpdateUser(ApplicationUserDto userDtoUpdated);
    }
}
