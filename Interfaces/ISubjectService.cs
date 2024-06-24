using eStudent.Models;
using eStudent.Models.DTO;

namespace eStudent.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> CreateNewSubject(SubjectDto subjectDto);
        Task<Subject> UpdateSubjectById(int id, SubjectDto subjectDto);
        Task<Subject> DeleteSubjectById(int id);
    }
}
