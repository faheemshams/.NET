using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.CourseStudents.ToArray());
        }

        [HttpPost]
        public IActionResult AddItem(CreateCourseStudentDto enroll)
        {
            var reqCourse = _context.Cources.FirstOrDefault(x => x.CourseName.Equals(enroll.CourseName));
            var reqStudent = _context.Students.FirstOrDefault(x => x.StudentName.Equals(enroll.StudentName));

            if (reqCourse == null || reqStudent == null)
            {
                return NotFound();
            }

            _context.CourseStudents.Add(new CourseStudent
            {
                CourseID = reqCourse.CourseID,
                StudentID = reqStudent.StudentID,
            });
            _context.SaveChanges();
            return Ok();
        }
    }
}
