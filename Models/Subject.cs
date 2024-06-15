using System.Collections.Generic;

namespace eStudent.Models
{
    public enum ActivityType
    {
        Lecture,
        Auditory,
        Lab
    }

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CollegeDepartment Department { get; set; }
        public List<Professor> Professors { get; set; } = new List<Professor>();
        public List<Student> Students { get; set; } = new List<Student>();
        public Classroom Classroom { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }
        public int Semester { get; set; }

        public ActivityType Activity { get; set; }

        public int NumberOfActivities { get; set; }
    }
}
