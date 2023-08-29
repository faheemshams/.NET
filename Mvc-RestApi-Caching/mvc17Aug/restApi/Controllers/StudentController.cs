using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly DatabaseContext _context;
        public StudentController(DatabaseContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students.ToArray());
        }

        [HttpPost]
        public IActionResult AddItem(CreateStudentDto student)
        {
            _context.Students.Add(new Student
            {
                StudentName = student.StudentName,
                StudentPhone = student.StudentPhone,
            });
            _context.SaveChanges();
            return Ok();
        }

        [Route("item")]
        [HttpGet]
        public IActionResult GetItem(int id)
        {
            var item = _context.Students.FirstOrDefault(x => x.StudentID == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut]
        public IActionResult UpdateItem(Student student)
        {
            var item = _context.Students.FirstOrDefault(x => x.StudentID == student.StudentID);
            if (item == null)
            {
                return NotFound();
            }
            item.StudentName = student.StudentName;
            item.StudentPhone = student.StudentPhone;
            _context.SaveChanges();
            return Ok(item);
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var reqStudent = _context.Students.FirstOrDefault(x => x.StudentID == id);
            if (reqStudent == null) 
            {
                return NotFound();
            }
            _context.Remove(reqStudent);
            _context.SaveChanges();
            return Ok();
        }
    }
}
