using Microsoft.EntityFrameworkCore;

namespace Day9_HW.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
