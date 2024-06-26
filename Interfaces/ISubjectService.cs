using eStudent.Models;
using eStudent.Models.DTO;
using eStudent.Query;

namespace eStudent.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjects(SubjectQuery subjectQuery);
        Task<Subject> GetSubjectById(int id);
        Task<Subject> CreateNewSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        Task<Subject> DeleteSubjectById(int id);
    }
}
