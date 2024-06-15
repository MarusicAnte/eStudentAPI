using System.Collections.Generic;

namespace eStudent.Models
{
    public class CollegeDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Professor> Professors { get; set; } 
        public List<Student> Students { get; set; } 
    }
}
