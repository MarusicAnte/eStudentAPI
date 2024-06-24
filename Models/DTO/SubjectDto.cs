using eStudent.Services;

namespace eStudent.Models.DTO
{
    public class SubjectDto
    {
        public string Name { get; set; }
        public string Semester { get; set; }
        public int ECTS { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public List<CollegeDepartment> Departments { get; set; }
    }
}
