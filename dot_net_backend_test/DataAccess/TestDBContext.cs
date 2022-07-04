using dot_net_backend_test.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace dot_net_backend_test.DataAccess
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options): base(options) { }

        public DbSet<User>? Users { get; set; } 
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapters>? Chapters { get; set; }
        public DbSet<Theme>? Themes { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
    }
}
