using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using eStudent.Constants;
using eStudent.Models.DTO;
using eStudent.Query;

namespace eStudent.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _dbContext;

        public UserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<User>> GetAllUsers(UserQuery userQuery)
        {
            var users = await _dbContext.Users.Include("Role").ToListAsync();

            if (users is null) 
            {
                throw new Exception("Users doesn't exist !");
            }

            return users;
        }


        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
            
            if(user == null)
            {
                throw new Exception($"User with id {id} does not exist !");
            }

            return user;
        }


        public async Task<User> CreateUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                RoleId = createUserDto.RoleId,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                ImageURL = createUserDto.ImageURL
            };

            if (user is null) 
            {
                throw new Exception($"User is null");
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;           
        }


        public async Task<User> UpdateUserById(int id, UserDto userDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);


            if (user is null)
            {
                throw new Exception("User updated failed !");
            }

            user.Role = userDto.Role;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.ImageURL = userDto.ImageURL;
           

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }


        public async Task<User> DeleteUserById(int id)
        {
            var user= await _dbContext.Users.FirstOrDefaultAsync( x => x.Id == id);

            if (user == null)
            {
                throw new Exception($"User with id {id} does not exist !");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
