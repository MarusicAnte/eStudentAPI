using eStudent.Data;
using eStudent.Interfaces;
using eStudent.Models;
using eStudent.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace eStudent.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDBContext _dbContext;

        public SubjectService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _dbContext.Subjects.ToListAsync();

            if (subjects is null)
            { 
                throw new Exception("Subject doesn't exist !");
            }

            return subjects;
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


        public async Task<Subject> CreateNewSubject(SubjectDto subjectDto)
        {
            if (subjectDto is null)
            {
                throw new Exception("Subject create data is null !");
            }

            var subject = new Subject
            {
                Name = subjectDto.Name,
                Semester = subjectDto.Semester,
                ECTS = subjectDto.ECTS,
                Description = subjectDto.Description,
                Users = subjectDto.Users,
                Departments = subjectDto.Departments
            };

            _dbContext.Subjects.Add(subject);
            await _dbContext.SaveChangesAsync();

            return subject;
        }


        public async Task<Subject> UpdateSubjectById(int id, SubjectDto subjectDto)
        {
            if (subjectDto is null)
            { 
                throw new Exception("SubjectDto is null !");
            }

            var subject = await _dbContext.Subjects.FindAsync(id);

            if (subject is null)
            {
                throw new Exception($"Subject with id {id} doesn't exist !");
            }

            subject.Name = subjectDto.Name;
            subject.Semester = subjectDto.Semester;
            subject.ECTS = subjectDto.ECTS;
            subject.Description = subjectDto.Description;
            subject.Users = subjectDto.Users;
            subject.Departments = subjectDto.Departments;

            _dbContext.Subjects.Update(subject);
            await _dbContext.SaveChangesAsync();

            return subject;
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
    }
}
