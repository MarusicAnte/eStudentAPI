namespace eStudent.Models
{
    public class ClassAttendance
    {
        public int Id { get; set; }
        public string ClassType { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool isPresent { get; set; }
    }
}
