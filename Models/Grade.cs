namespace eStudent.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<GradeType> Grades { get; set; }
        public string Description { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
