namespace eStudent.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string ActivityGroup { get; set; }
        public List<Professor> Professors { get; set; } = new List<Professor>();
        public List<Student> Students { get; set; } = new List<Student>();
        public Classroom Classroom { get; set; }
        public DateTime ActivityStartTime { get; set; }
        public DateTime ActivityEndTime { get; set; }
    }
}
