using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    
    public class CourseController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMemoryCache _cache;

        public CourseController(DatabaseContext _context, IMemoryCache _cache)
        {
            this._context = _context;
            this._cache = _cache;   
        }

        [Route("CourseList")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cacheKey = "courseList";
            if(!_cache.TryGetValue(cacheKey, out List<Course> courseList)) 
            {
                courseList = await _context.Cources.ToListAsync();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                };
                _cache.Set(cacheKey, courseList, cacheExpiryOptions);   
            }
            return Ok(courseList);
        }

        [Route("AddCourse")]
        [HttpPost]
        public async Task<IActionResult> AddItemAsync(CreateCourseDto course)
        {
            await _context.Cources.AddAsync(new Course
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,   
                CourseCredit = course.CourseCredit,
            });

            await _context.SaveChangesAsync();
           _cache.Remove("courseList");
            return Ok();
        }

        [HttpGet]
        [Route("getCourse")]
        public async Task<IActionResult> GetItemAsync(int id) 
        {
            var item = await _context.Cources.FirstOrDefaultAsync(x => x.CourseID == id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);    
        }

        [HttpPut]
        [Route("UpdateCourse")]
        public async Task<IActionResult> UpdateItemAsync(Course course)
        {
            var item = await _context.Cources.FirstOrDefaultAsync(x => x.CourseID == course.CourseID);
            if (item == null)
            {
                return NotFound();
            }
            item.CourseName = course.CourseName;
            item.CourseDescription = course.CourseDescription;
            item.CourseCredit = course.CourseCredit;
            await _context.SaveChangesAsync();
            _cache.Remove("courseList");
            return Ok(item);
        }

        [HttpDelete]
        [Route("DeleteCourse")]

        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            var reqCourse = await _context.Cources.FirstOrDefaultAsync(x => x.CourseID == id);
            if (reqCourse == null) 
            {
                return NotFound();
            }
            _context.Remove(reqCourse);
            await _context.SaveChangesAsync();
            _cache.Remove("courseList");
            return Ok();
        }
    }

}

