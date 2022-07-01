using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudentsWhereCourseId(int courseId);

        IEnumerable<Student> GetStudentsWithNoCourses();
    }
}
