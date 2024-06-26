using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using eStudent.Query;
using Microsoft.EntityFrameworkCore;

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
            var users = await userQuery.GetUserQuery(_dbContext.Users.Include(x => x.Role).Include(x => x.Subjects)).ToListAsync();

            return users.Count is 0 ? throw new Exception("Users doesn't exist !") : users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
                throw new Exception($"User with id {id} does not exist !");

            return user;
        }

        public async Task<User> CreateNewUser(User user)
        {
            user.Subjects = await GetSubjectsForUser(user);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var target = await _dbContext.Users.Include(x => x.Role)
                                               .Include(x => x.Subjects)
                                               .FirstOrDefaultAsync(x => x.Id == user.Id);

            if (target is null)
                throw new Exception($"User with id {user.Id} doesn't exist !");

            target.RoleId = user.Role?.Id?? user.RoleId;
            target.FirstName = user.FirstName;
            target.LastName = user.LastName;
            target.Email = user.Email;
            target.Password = user.Password;
            target.ImageURL = user.ImageURL;
            target.Subjects = await GetSubjectsForUser(user);

            _dbContext.Users.Update(target);
            await _dbContext.SaveChangesAsync();

            return target;
        }

        public async Task<User> DeleteUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user is null)
                throw new Exception($"User with id {id} does not exist !");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        private async Task<List<Subject>> GetSubjectsForUser(User user)
        {
            if (user.Subjects is null || user.Subjects.Count is 0)
                return new List<Subject>();

            var subjectsIds = user.Subjects.Select(x => x.Id).ToList();

            return await _dbContext.Subjects.Where(x => subjectsIds.Contains(x.Id)).ToListAsync();
        }

        private async Task<List<CollegeDepartment>> GetCollegeDepartmentsForUser(User user)
        {
            if (user.Departments is null || user.Departments.Count is 0)
                return new List<CollegeDepartment>();

            var collegeDepartmentsIds = user.Departments.Select(x => x.Id).ToList();

            return await _dbContext.CollegeDepartments.Where(x => collegeDepartmentsIds.Contains(x.Id)).ToListAsync();
        }
    }
}