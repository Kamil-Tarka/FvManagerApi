using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FvManagerApi.Controllers
{
    [Route("api/fvmanager/user")]
    [ApiController]
    [Authorize(Roles = "Admin", Policy = "IsUserAccoundActive")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("enable/{userId}")]
        public ActionResult EnableUser([FromRoute]int userId)
        {
            _userService.EnableUser(userId);

            return Ok();
        }

        [HttpPost("disable/{userId}")]
        public ActionResult DisableUser([FromRoute] int userId)
        {
            _userService.DisableUser(userId);

            return Ok();
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            var result = _userService.GetAll();

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetById([FromRoute]int userId)
        {
            var result = _userService.GetById(userId);

            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser([FromRoute] int userId)
        {
            _userService.Delete(userId);

            return NoContent();
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateUser([FromRoute] int userId, [FromBody]UpdateUserDto dto)
        {
            _userService.Update(userId, dto);

            return Ok();
        }
    }
}
