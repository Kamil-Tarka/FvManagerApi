using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Services
{
    public interface IUserService
    {
        void EnableUser(int userId);
        void DisableUser(int userId);
        void Delete(int userId);
        void Update(int userId, UpdateUserDto dto);
        PagetResult<UserDto> GetAll(UserQuery userQuery);
        UserDto GetById(int userId);
    }
}
