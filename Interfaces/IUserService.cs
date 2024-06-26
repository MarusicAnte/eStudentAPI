using eStudent.Models;
using eStudent.Models.DTO;
using eStudent.Query;

namespace eStudent.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers(UserQuery userQuery);
        Task<User> GetUserById(int id);
        Task<User> CreateNewUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUserById(int id);
    }
}
