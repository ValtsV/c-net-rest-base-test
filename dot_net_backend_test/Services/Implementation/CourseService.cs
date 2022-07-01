using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class CourseService : ICourseService
    {
        public IEnumerable<Course> GetCoursesWhereStudentId(int studentId)
        {
            var courses = new List<Course>();
            return (IEnumerable<Course>)courses.SelectMany(c => c.Students).Where(student => student.Id == studentId).ToList();
        }

        public IEnumerable<Course> GetCoursesWithCategoryId(int categoryId)
        {
            var courses = new List<Course>();
            return (IEnumerable<Course>)courses.SelectMany(c => c.Categories).Where(category => category.Id == categoryId).ToList();
        }

        public IEnumerable<Course> GetCoursesWithNoChapters()
        {
            var courses = new List<Course>();
            return courses.Where(c => c.Chapter != null);


        }
    }
}
