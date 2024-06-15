namespace eStudent.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<SubjectSchedule> SubjectSchedules { get; set; } = new List<SubjectSchedule>();
    }

    public class SubjectSchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SubjectStartTime { get; set; }
        public DateTime SubjectEndTime { get; set; }
        public Classroom Classroom { get; set; }
        public Professor Professor { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
