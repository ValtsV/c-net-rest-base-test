using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Models.DataModels;
using dot_net_backend_test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace dot_net_backend_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly TestDBContext _context;
        private readonly ICourseService _courseService;
        private readonly ILogger<ChaptersController> _logger;

        public CoursesController(TestDBContext context, ICourseService courseService, ILogger<ChaptersController> logger)
        {
            _context = context;
            _courseService = courseService;
            _logger = logger;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
          if (_context.Courses == null)
          {
              return NotFound();
          }
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
          if (_context.Courses == null)
          {
              return NotFound();
          }
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // GET: api/Courses/students/1
        [HttpGet("GetCoursesWhereStudentId/{id}")]
        public  IEnumerable<Course> GetCoursesWhereStudentId(int id)
        {
            return _courseService.GetCoursesWhereStudentId(id);
        }

        // GET: api/Courses/category/1
        [HttpGet("GetCoursesWithCategoryId/{id}")]
        public IEnumerable<Course> GetCoursesWithCategoryId(int id)
        {
            return _courseService.GetCoursesWhereCategoryId(id);
        }

        // GET: api/Courses/chapters/themes?count=0
        [HttpGet("GetCoursesWithNoThemes")]
        public IEnumerable<Course> GetCoursesWithNoThemes()
        {
            return _courseService.GetCoursesWithNoThemes();
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CourseExists(id))
                {
                    _logger.LogError($"{nameof(CoursesController)} - {nameof(PutCourse)} - Couldn't update course with id {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"{nameof(CoursesController)} - {nameof(PutCourse)} - Couldn't update course with id {id}");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
          if (_context.Courses == null)
          {
                _logger.LogError($"{nameof(CoursesController)} - {nameof(PostCourse)} - Entity set 'TestDBContext.Courses' is null.");

              return Problem("Entity set 'TestDBContext.Courses'  is null.");
          }
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
