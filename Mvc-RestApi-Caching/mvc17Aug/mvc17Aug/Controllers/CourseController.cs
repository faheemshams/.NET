using Microsoft.AspNetCore.Mvc;
using mvc17Aug.Models;

namespace mvc17Aug.Controllers
{
    public class CourseController : Controller
    {
        private readonly IRepository<Course> _repository;

        public CourseController(IRepository<Course> repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            var data = _repository.GetAll();
            return View(data); 
        }
   
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            _repository.Add(course);
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var course = _repository.GetAll().Where(x => x.CourseID == id).Single();
            return View("Delete",course);
        }


        [HttpPost]
        public IActionResult Delete(Course course)
        {
            _repository.Delete(course.CourseID);
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
            return View("Index", _repository.GetAll());
        }
    }
}
