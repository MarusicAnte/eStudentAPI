using eStudent.Models;

namespace eStudent.Interfaces
{
    public interface ICollegeDepartmentService
    {
        Task<List<CollegeDepartment>> GetAllCollegeDepartments();
        Task<CollegeDepartment> GetCollegeDepartmentById(int id);
        Task<CollegeDepartment> CreateNewCollegeDepartment(CollegeDepartment collegeDepartment);
        Task<CollegeDepartment> UpdateCollegeDepartment(CollegeDepartment collegeDepartment);
        Task<CollegeDepartment> DeleteCollegeDepartmentById(int id);
    }
}
