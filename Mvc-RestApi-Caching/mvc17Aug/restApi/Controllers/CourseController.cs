using Microsoft.AspNetCore.Mvc;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CourseController(DatabaseContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Cources.ToArray());
        }

        [HttpPost]
        public IActionResult AddItem(CreateCourseDto course)
        {
            _context.Cources.Add(new Course
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,   
                CourseCredit = course.CourseCredit,
            });
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("id")]
        public IActionResult GetItem(int id) 
        {
            var item = _context.Cources.FirstOrDefault(x => x.CourseID == id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);    
        }

        [HttpPut]
        [Route("id")]
        public IActionResult UpdateItem(Course course)
        {
            var item = _context.Cources.FirstOrDefault(x => x.CourseID == course.CourseID);
            if (item == null)
            {
                return NotFound();
            }
            item.CourseName = course.CourseName;
            item.CourseDescription = course.CourseDescription;
            item.CourseCredit = course.CourseCredit;
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete]
        [Route("id")]

        public IActionResult Delete(int id)
        {
            var reqCourse = _context.Cources.FirstOrDefault(x => x.CourseID == id);
            if (reqCourse == null) 
            {
                return NotFound();
            }
            _context.Remove(reqCourse);
            _context.SaveChanges();
            return Ok();
        }
    }

}

