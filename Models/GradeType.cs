namespace eStudent.Models
{
    public class GradeType
    {
        public int Id { get; set; }
        public string Type { get; set; } // Seminar, lab ili ukupna ocjena
        public List<int> Values { get; set; }
        public string Description { get; set; }
    }
}
