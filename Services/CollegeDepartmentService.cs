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
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;

        public CollegeDepartmentService(ApplicationDBContext dbContext, IUserService userService, ISubjectService subjectService) 
        {
            _dbContext = dbContext;
            _userService = userService;
            _subjectService = subjectService;
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
                                                            .Include(x => x.Id==collegeDepartment.Id)
                                                            .FirstOrDefaultAsync();
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


        public ValueTask<List<User>> GetUsersForCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            if (collegeDepartment.Users is null || collegeDepartment.Users?.Count is 0)
                return new ValueTask<List<User>>([]);

            return new ValueTask<List<User>>(_userService.GetAllUsers(
                   new UserQuery()
                   {
                       Ids = collegeDepartment.Users.Select(x => x.Id).ToList()
                   }
                ));
        }


        public ValueTask<List<Subject>> GetSubjectsForCollegeDepartment(CollegeDepartment collegeDepartment)
        {
            if (collegeDepartment.Subjects is null || collegeDepartment.Subjects?.Count is 0)
                return new ValueTask<List<Subject>>([]);

            return new ValueTask<List<Subject>>(_subjectService.GetAllSubjects(
                   new SubjectQuery()
                   {
                       Ids = collegeDepartment.Subjects.Select(x => x.Id).ToList()
                   }
                ));
        }
    }
}
