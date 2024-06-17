namespace eStudent.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; } 
        public Subject Subject { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
