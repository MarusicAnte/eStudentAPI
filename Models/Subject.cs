using System.Collections.Generic;

namespace eStudent.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CollegeDepartment Department { get; set; }
        public string Semester { get; set; }
        public int ECTS { get; set; }
        public string Description { get; set; }
        public List<ActivityType> Activities { get; set; }
    }
}
