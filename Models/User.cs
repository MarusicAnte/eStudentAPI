using eStudent.Constants;
using System.Data;

namespace eStudent.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string? ImageURL { get; set; }

        #region Relations
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<CollegeDepartment> Departments { get; set; }
        #endregion

        public bool IsAdmin()
        {
            return Role.Name.Equals(RolesConstant.Admin);
        }
        public bool IsStudent()
        {
            return Role.Name.Equals(RolesConstant.Student);
        }
        public bool IsProfessor()
        {
            return Role.Name.Equals(RolesConstant.Professor);
        }
    }
}