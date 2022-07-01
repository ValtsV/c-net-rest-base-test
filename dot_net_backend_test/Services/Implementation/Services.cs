using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class Services : IServices
    {
        public IEnumerable<Course> GetCoursesWithLevelAndCategory(Level level, Category category)
        {
            var courses = new List<Course>();
            return courses.Where(course => course.Categories == category && course.Level == level);
        }

        public IEnumerable<Course> GetCoursesWithLevelAndHasStudents(Level level)
        {
            var courses = new List<Course>();
            return courses.Where(course => course.Students.Any() && course.Level == level);
        }

        public IEnumerable<Course> GetCoursesWithNoStudents()
        {
            var courses = new List<Course>();
            return courses.Where(course => !course.Students.Any());
        }

        public IEnumerable<Student> GetStudentsWhereAgeIsMoreThan18()
        {
            var students = new List<Student>();
            return students.Where(student =>
            {
                int val = DateTime.Compare(DateTime.Now.AddYears(-18), student.Dob);
                if (val >= 0)
                {
                    return true;
                }
                return false;
            });
        }

        public IEnumerable<Student> GetStudentsWithOneOrMoreCourses()
        {
            var students = new List<Student>();
            return students.Where(student => student.Courses.Any());
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            var users = new List<User>();
            return (from user in users where user.Email == email select user).ToList();
        }
    }
}

