using System.Collections.Generic;

namespace eStudent.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public int? ECTS { get; set; }
        public string Description { get; set; }
        //public List<ActivityType> Activities { get; set; }

        #region Relations
        public List<User> Users { get; set; }
        public List<CollegeDepartment> Departments { get; set; }
        #endregion
    }
}
