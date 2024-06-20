using eStudent.Models;
using eStudent.Models.DTO;
using eStudent.Query;

namespace eStudent.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers(UserQuery userQuery);
        Task<User> GetUserById(int id);
        Task<User> CreateUser(CreateUserDto createUserDto);
        Task<User> UpdateUserById(int id, UserDto userDto);
        Task<User> DeleteUserById(int id);
    }
}
