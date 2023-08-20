using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IMemoryCache _cache;
        public StudentController(DatabaseContext _context, IMemoryCache _cache)
        {
            this._context = _context;
            this._cache = _cache;
        }

        [Route("StudentsList")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cacheKey = "studentList";
            if(!_cache.TryGetValue(cacheKey, out List<Student> studentList))
            {
                studentList = await _context.Students.ToListAsync();
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                };
                _cache.Set(cacheKey, studentList, cacheExpiryOptions);
            }
            
            return Ok(studentList);
        }

        [Route("AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddItemAsync(CreateStudentDto student)
        {
            await _context.Students.AddAsync(new Student
            {
                StudentName = student.StudentName,
                StudentPhone = student.StudentPhone,
            });
            await _context.SaveChangesAsync();
            _cache.Remove("studentList");
            return Ok();
        }

        [Route("GetStudentById")]
        [HttpGet]
        public async Task<IActionResult> GetItemAsync(int id)
        {
            var item = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync(Student student)
        {
            var item = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == student.StudentID);
            if (item == null)
            {
                return NotFound();
            }
            item.StudentName = student.StudentName;
            item.StudentPhone = student.StudentPhone;
            await _context.SaveChangesAsync();
            _cache.Remove("studentList");
            return Ok(item);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var reqStudent = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == id);
            if (reqStudent == null) 
            {
                return NotFound();
            }
            _context.Remove(reqStudent);
            await _context.SaveChangesAsync();
            _cache.Remove("studentList");
            return Ok();
        }
    }
}
