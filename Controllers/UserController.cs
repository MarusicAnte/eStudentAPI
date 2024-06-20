using eStudent.Interfaces;
using eStudent.Models;
using eStudent.Models.DTO;
using eStudent.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<List<User>> GetAllUsers([FromQuery] UserQuery userQuery)
        {
            return await _userService.GetAllUsers(userQuery);
        }


        [HttpGet("{id}")]
        public async Task<User> GetUserById([FromRoute] int id)
        {
            return await _userService.GetUserById(id);
        }


        [HttpPost]
        public async Task<User> CreateUser([FromBody] CreateUserDto createUserDto ) 
        {
            return await _userService.CreateUser(createUserDto);
        }


        [HttpPatch("{id}")]
        public async Task<User> UpdateUserById([FromRoute] int id, [FromBody] UserDto userDto) 
        {
            return await _userService.UpdateUserById(id, userDto);
        }


        [HttpDelete("{id}")]
        public async Task<User> DeleteUserById([FromRoute] int id) 
        {
            return await _userService.DeleteUserById(id);
        }
    }
}
