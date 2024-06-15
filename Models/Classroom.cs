namespace eStudent.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
