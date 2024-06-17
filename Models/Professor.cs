namespace eStudent.Models
{
    public class Professor : User
    {
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public string Office { get; set; }
        public string Phone { get; set; }
    }
}
