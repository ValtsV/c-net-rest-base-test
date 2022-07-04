using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCoursesWhereCategoryId(int categoryId);

        IEnumerable<Course> GetCoursesWithNoThemes();

        IEnumerable<Course> GetCoursesWhereStudentId(int studentId);
    }
}
