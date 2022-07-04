using dot_net_backend_test.Models.DataModels;
using dot_net_backend_test.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_backend_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesTestController : ControllerBase
    {
        private readonly IServices _services;

        public ServicesTestController(IServices services) {
            this._services = services;
        }

        // GET api/ServicesTestcontroller/users?email=email
        [HttpGet("GetUserByEmail")]
        public IEnumerable<User> GetUserByEmail([FromQuery] string email)
        {
            return _services.GetUsersByEmail(email);
        }

        // GET api/ServicesTestcontroller/students/withCourses
        [HttpGet("GetStudentsWithOneOrMoreCourse")]
        public IEnumerable<Student> GetStudentsWithOneOrMoreCourse()
        {
            return _services.GetStudentsWithOneOrMoreCourses();
        }

        // GET api/ServicesTestcontroller/students/age
        [HttpGet("GetStudentsWhereAgeIsMoreThan18")]
        public IEnumerable<Student> GetStudentsWhereAgeIsMoreThan18()
        {
            return _services.GetStudentsWhereAgeIsMoreThan18();
        }

        // GET api/ServicesTestcontroller/courses/no-students
        [HttpGet("GetCoursesWithNoStudents")]
        public IEnumerable<Course> GetCoursesWithNoStudents()
        {
            return _services.GetCoursesWithNoStudents();
        }

        // GET api/ServicesTestcontroller/courses/level/{level}
        [HttpGet("GetCoursesWithLevelAndHasStudents/level/{level}")]
        public IEnumerable<Course> GetCoursesWithLevelAndHasStudents(int level)
        {
            return _services.GetCoursesWithLevelAndHasStudents(level);
        }

        // GET api/ServicesTestcontroller/courses/category/{categoryId}/level/{level}
        [HttpGet("GetCoursesWithLevelAndCategory/category/{categoryId}/level/{level}")]
        public IEnumerable<Course> GetCoursesWithLevelAndCategory(int categoryId, int level)
        {
            return _services.GetCoursesWithLevelAndCategory(level, categoryId);
        }


    }
}
