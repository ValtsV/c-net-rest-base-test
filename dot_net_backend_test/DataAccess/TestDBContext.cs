using dot_net_backend_test.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace dot_net_backend_test.DataAccess
{
    public class TestDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public TestDBContext(DbContextOptions<TestDBContext> options, ILoggerFactory loggerFactory): base(options) {
            _loggerFactory = loggerFactory;
        }

        public DbSet<User>? Users { get; set; } 
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapters>? Chapters { get; set; }
        public DbSet<Theme>? Themes { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<TestDBContext>();
            //optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            //optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();

        }
    }
}
