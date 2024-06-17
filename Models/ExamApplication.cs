using System;

namespace eStudent.Models
{
    public class ExamApplication
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } 
        public int StudentId { get; set; } 
        public Student Student { get; set; }
        public int SubjectId { get; set; } 
        public Subject Subject { get; set; }
    }
}
