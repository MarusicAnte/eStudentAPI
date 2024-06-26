using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using eStudent.Query;
using Microsoft.EntityFrameworkCore;

namespace eStudent.Services
{
    public class CollegeDepartmentService : ICollegeDepartmentService
    {
        private readonly ApplicationDBContext _dbContext;

        public CollegeDepartmentService(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<CollegeDepartment>> GetAllCollegeDepartments()
        {
            var collegeDepartments = await _dbContext.CollegeDepartments.ToListAsync();

            return collegeDepartments.Count is 0 ? throw new Exception("College departments does not exist !") 
                   : collegeDepartments;
        }


        public async Task<CollegeDepartment> GetCollegeDepartmentById(int id)
        {
            var collegeDepartment = await _dbContext.CollegeDepartments.FirstOrDefaultAsync(x => x.Id == id);

            if (collegeDepartment is null)
                throw new Exception($"College department with id {id} does not exist !");

            return collegeDepartment;
        }


        public async Task<CollegeDepartment> CreateNewCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            collegeDepartment.Users = await GetUsersForCollegeDepartment(collegeDepartment);
            collegeDepartment.Subjects = await GetSubjectsForCollegeDepartment(collegeDepartment);
            
            _dbContext.CollegeDepartments.Add(collegeDepartment);
            await _dbContext.SaveChangesAsync();

            return collegeDepartment;

        }


        public async Task<CollegeDepartment> UpdateCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            var target = await _dbContext.CollegeDepartments.Include(x => x.Users)
                                                            .Include(x => x.Subjects)
                                                            .FirstOrDefaultAsync(x => x.Id == collegeDepartment.Id);
            if (target is null)
                throw new Exception($"College department with id {collegeDepartment.Id} does not exist !");

            target.Name = collegeDepartment.Name;
            target.Description = collegeDepartment.Description;
            target.Users = await GetUsersForCollegeDepartment(collegeDepartment);
            target.Subjects = await GetSubjectsForCollegeDepartment(collegeDepartment);

            _dbContext.CollegeDepartments.Update(collegeDepartment);
            await _dbContext.SaveChangesAsync();

            return collegeDepartment;
        }


        public async Task<CollegeDepartment> DeleteCollegeDepartmentById(int id)
        {
            var collegeDepartment = await _dbContext.CollegeDepartments.FindAsync(id);

            if (collegeDepartment is null)
                throw new Exception($"User with id {id} does not exist !");

            _dbContext.CollegeDepartments.Remove(collegeDepartment);
            await _dbContext.SaveChangesAsync();

            return collegeDepartment;
        }


        public async Task<List<User>> GetUsersForCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            if (collegeDepartment.Users is null || collegeDepartment.Users.Count is 0)
                return new List<User>();

            var usersIds = collegeDepartment.Users.Select(x => x.Id).ToList();

            return await _dbContext.Users.Where(x => usersIds.Contains(x.Id)).ToListAsync();
        }


        public async Task<List<Subject>> GetSubjectsForCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            if (collegeDepartment.Subjects is null || collegeDepartment.Subjects.Count is 0)
                return new List<Subject>();

            var subjectIds = collegeDepartment.Subjects.Select(x => x.Id).ToList();

            return await _dbContext.Subjects.Where(x => subjectIds.Contains(x.Id)).ToListAsync();
        }
    }
}
