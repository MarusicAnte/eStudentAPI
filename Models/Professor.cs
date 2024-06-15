namespace eStudent.Models
{
    public class Professor : User
    {
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public string OfficeLocation { get; set; }
        public string OfficeHours { get; set; }
    }
}
