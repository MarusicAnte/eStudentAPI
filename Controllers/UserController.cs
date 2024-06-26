using eStudent.Interfaces;
using eStudent.Models;
using eStudent.Models.DTO;
using eStudent.Query;
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
        public async Task<User> CreateNewUser([FromBody] UserDto userDto ) 
        {
            return await _userService.CreateNewUser(userDto.ToDomain());
        }


        [HttpPatch]
        public async Task<User> UpdateUser([FromBody] UserDto userDto) 
        {
            return await _userService.UpdateUser(userDto.ToDomain());
        }


        [HttpDelete("{id}")]
        public async Task<User> DeleteUserById([FromRoute] int id) 
        {
            return await _userService.DeleteUserById(id);
        }
    }
}
