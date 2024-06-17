namespace eStudent.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
