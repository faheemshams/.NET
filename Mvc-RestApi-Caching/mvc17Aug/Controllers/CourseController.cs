using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc17Aug.Models;

namespace mvc17Aug.Controllers
{
    [Authorize(Roles = "professor, admin")]
    public class CourseController : Controller
    {
        private readonly IRepository<Course> _repository;
        private readonly ILogger _logger;

        public CourseController(IRepository<Course> repository, ILogger _logger)
        {
            this._repository = repository;
            this._logger = _logger;
        }
        
        public IActionResult Index()
        {
            var data = _repository.GetAll();
            return View(data); 
        }
   
        [Authorize(Policy = "ProbationOver")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            _repository.Add(course);
            _logger.AddLog(1, "added course");
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int id) {
            var course = _repository.GetAll().Where(x => x.CourseID == id).FirstOrDefault();
            _repository.Delete(id);
            return View("Delete",course);
        }

        [HttpPost]
        public IActionResult Delete(Course course)
        {
            _repository.Delete(course.CourseID);
            _logger.AddLog(1, "Deleted Course");
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var course = _repository.GetAll().Where(x => x.CourseID == id).Single();
            return View(course);
        }

        [HttpPost]
        public IActionResult Update(Course course)
        {
            var item = _repository.GetAll().Where(x => x.CourseID == course.CourseID).Single();
            item.CourseName = course.CourseName;
            item.CourseCredit = course.CourseCredit;
            item.CourseDescription = course.CourseDescription;
            _repository.Update(item);
            _logger.AddLog(1, "updated Course");
            return View("Index", _repository.GetAll());
        }
    }
}
