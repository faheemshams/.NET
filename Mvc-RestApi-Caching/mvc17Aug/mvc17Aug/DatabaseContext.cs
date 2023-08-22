using Microsoft.EntityFrameworkCore;
using mvc17Aug.Models;

namespace mvc17Aug
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> Cources { get; set; }  
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
    }
}
