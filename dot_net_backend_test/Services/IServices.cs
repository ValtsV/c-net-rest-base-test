using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services
{
    public interface IServices
    {
        IEnumerable<User> GetUsersByEmail(string email);

        IEnumerable<Student> GetStudentsWhereAgeIsMoreThan18();

        IEnumerable<Student> GetStudentsWithOneOrMoreCourses();

        IEnumerable<Course> GetCoursesWithLevelAndHasStudents(Level level);

        IEnumerable<Course> GetCoursesWithLevelAndCategory(Level level, Category category);

        IEnumerable<Course> GetCoursesWithNoStudents();
    }
}