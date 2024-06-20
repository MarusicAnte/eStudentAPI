using System.Linq;
using System.Threading.Tasks;
using eStudent.Models;
using Microsoft.EntityFrameworkCore;

namespace eStudent.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    //public DbSet<Subject> Subjects { get; set; }
    //public DbSet<CollegeDepartment> CollegeDepartments { get; set; }
    //public DbSet<ClassAttendance> ClassAttendances { get; set; }
    //public DbSet<Grade> Grades { get; set; }
    //public DbSet<Classroom> Classrooms { get; set; }
    //public DbSet<Schedule> Schedules { get; set; }
    //public DbSet<Notification> Notifications { get; set; }
    //public DbSet<ExamApplication> ExamApplications { get; set; }
}
