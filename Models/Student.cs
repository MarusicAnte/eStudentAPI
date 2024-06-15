namespace eStudent.Models
{
    public class Student : User
    {
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public int YearOfStudy { get; set; }
    }
}
