using System.Collections.Generic;

namespace eStudent.Models
{
    public class CollegeDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region Relations
        public List<Subject> Subjects { get; set; }
        public List<User>  Users { get; set; }
        #endregion
    }
}
