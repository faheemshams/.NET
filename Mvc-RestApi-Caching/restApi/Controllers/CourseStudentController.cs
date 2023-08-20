using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    public class CourseStudentController : Controller
    {
        private readonly DatabaseContext _context;

        public CourseStudentController(DatabaseContext _context)
        {
            this._context = _context;
        }

        [Route("EnrollmentList")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _context.CourseStudents.ToListAsync());
        }

        [Route("AddEnrollment")]
        [HttpPost]
        public async Task<IActionResult> AddItemAsync(CreateCourseStudentDto enroll)
        {
            var reqCourse = await _context.Cources.FirstOrDefaultAsync(x => x.CourseName.Equals(enroll.CourseName));
            var reqStudent = await _context.Students.FirstOrDefaultAsync(x => x.StudentName.Equals(enroll.StudentName));

            if (reqCourse == null || reqStudent == null)
            {
                return NotFound();
            }

            await _context.CourseStudents.AddAsync(new CourseStudent
            {
                CourseID = reqCourse.CourseID,
                StudentID = reqStudent.StudentID,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
