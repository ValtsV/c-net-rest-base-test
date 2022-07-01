using dot_net_backend_test.Models.DataModels;

namespace dot_net_backend_test.Services.Implementation
{
    public class StudentService : IStudentService
    {
        public IEnumerable<Student> GetStudentsWhereCourseId(int courseId)
        {
            var students = new List<Student>();
            return (IEnumerable<Student>)students.SelectMany(student => student.Courses).Where(course => course.Id == courseId).ToList();

        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            var students = new List<Student>();
            return students.Where(student => student.Courses.Count == 0);
        }
    }

        
    
}
