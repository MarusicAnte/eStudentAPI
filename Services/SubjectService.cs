using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using eStudent.Query;
using Microsoft.EntityFrameworkCore;

namespace eStudent.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IUserService _userService;
        private readonly ICollegeDepartmentService _collegeDepartmentService;

        public SubjectService(ApplicationDBContext dbContext, IUserService userService
                             ICollegeDepartmentService collegeDepartmentService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _collegeDepartmentService = collegeDepartmentService;
        }


        public async Task<List<Subject>> GetAllSubjects(SubjectQuery subjectQuery)
        {
            var subjects = await subjectQuery.GetSubjectQuery(_dbContext.Subjects).ToListAsync();

            return subjects.Count is 0 ? throw new Exception("Subjss doesn't exist !") : subjects;
        }


        public async Task<Subject> GetSubjectById(int id)
        {
            var subject = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);

            if (subject is null)
            { 
                throw new Exception($"Subject with id {id} doesn't exist !");
            }

            return subject;
        }


        public async Task<Subject> CreateNewSubject(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
            await _dbContext.SaveChangesAsync();

            return subject;
        }


        public async Task<Subject> UpdateSubject(Subject subject)
        {
            var target = await _dbContext.Subjects.Include(x => x.Users)
                                                  .FirstOrDefaultAsync(x => x.Id==subject.Id);

            if (target is null)
                throw new Exception($"Subject with id {subject.Id} doesn't exist !");

            target.Name = subject.Name;
            target.Semester = subject.Semester;
            target.ECTS = subject.ECTS;
            target.Description = subject.Description;
            target.Users = await GetUsersForSubject(subject);
            //subject.Departments = subjectDto.Departments;

            _dbContext.Subjects.Update(target);
            await _dbContext.SaveChangesAsync();

            return target;
        }


        public async Task<Subject> DeleteSubjectById(int id)
        {
            var subject = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);

            if (subject is null)
            {
                throw new Exception($"Subject with id {id} doesn't exist !");
            }

            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();

            return subject;
        }


        private ValueTask<List<User>> GetUsersForSubject(Subject subject)
        {
            if (subject.Users is null || subject.Users?.Count is 0)
                return new ValueTask<List<User>>([]);

            return new ValueTask<List<User>>(_userService.GetAllUsers(
                   new UserQuery()
                   {
                       Ids = subject.Users.Select(x => x.Id).ToList()
                   }
               ));
        }


        private ValueTask<List<CollegeDepartment>> GetCollegeDepartmentsForSubject(Subject subject)
        {
            if (subject.Departments is null || subject.Departments?.Count is 0)
                return new ValueTask<List<CollegeDepartment>>([]);

            return new ValueTask<List<CollegeDepartment>>(_collegeDepartmentService.GetAllCollegeDepartments(
                   new CollegeDepartmentQuery()
                   {
                       Ids = subject.Departments.Select(x => x.Id).ToList()
                   }
               ));
        }
    }
}
