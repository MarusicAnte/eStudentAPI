namespace eStudent.Models
{
    public class UserAttendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public List<ClassAttendance> LectureAttendance { get; set; } = new List<ClassAttendance>();
        public List<ClassAttendance> AuditoryAttendance { get; set; } = new List<ClassAttendance>();
        public List<ClassAttendance> LaboratoryAttendance { get; set; } = new List<ClassAttendance>();
    }
}
