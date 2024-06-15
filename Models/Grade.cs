namespace eStudent.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; } 
        public Student Student { get; set; } 
        public int SubjectId { get; set; } 
        public Subject Subject { get; set; } 
        public GradeType SeminarGrade { get; set; } 
        public GradeType LaboratoryGrade { get; set; } 
        public GradeType TotalGrade { get; set; } 
        public string Description { get; set; }

        public Grade()
        {
            SeminarGrade = GradeType.Unknown;
            LaboratoryGrade = GradeType.Unknown;
            TotalGrade = GradeType.Unknown;
        }
    }

    public enum GradeType
    {
        Unknown = -1,
        F = 1,
        D = 2,
        C = 3,
        B = 4,
        A = 5
    }
}
