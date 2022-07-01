using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCoursesWithCategoryId(int categoryId);

        IEnumerable<Course> GetCoursesWithNoChapters();

        IEnumerable<Course> GetCoursesWhereStudentId(int studentId);
    }
}
