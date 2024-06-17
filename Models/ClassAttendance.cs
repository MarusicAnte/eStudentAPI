namespace eStudent.Models
{
    public class ClassAttendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } // Datum prisutnosti
        public string ClassType { get; set; } // Predavanja, auditorne ili labovi
        public int UserId { get; set; } // Id usera
        public string UserName { get; set; } // Ime studenta/profesora
        public bool isPresent { get; set; } // Da li je bija prisutan tad i tad.
    }
}
