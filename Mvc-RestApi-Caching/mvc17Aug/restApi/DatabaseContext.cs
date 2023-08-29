using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace restApi
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> Cources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
    }
}
