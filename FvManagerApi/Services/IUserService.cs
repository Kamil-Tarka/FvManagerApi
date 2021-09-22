using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;

namespace FvManagerApi.Services
{
    public interface IUserService
    {
        void EnableUser(int userId);
        void DisableUser(int userId);
        void Delete(int userId);
        void Update(int userId, UpdateUserDto dto);
        List<UserDto> GetAll();
        UserDto GetById(int userId);
    }
}
