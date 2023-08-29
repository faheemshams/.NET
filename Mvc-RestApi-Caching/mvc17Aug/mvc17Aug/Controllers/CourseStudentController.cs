using Microsoft.AspNetCore.Mvc;
using mvc17Aug.Models;
using mvc17Aug;
using NuGet.Protocol.Core.Types;

namespace mvc17Aug.Controllers
{
    public class CourseStudentController : Controller
    {
        private readonly IRepository<CourseStudent> _courseStudentRepository;

        public CourseStudentController(IRepository<CourseStudent> repository)
        {
            _courseStudentRepository = repository;
        }

        public IActionResult Index()
        {
            return View(_courseStudentRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // we go to Index after enrolling, post after submit form
        [HttpPost]
        public IActionResult Add(CourseStudent courseStudentObj)
        {
           _courseStudentRepository.Add(courseStudentObj);
            return View("Index",_courseStudentRepository.GetAll());
        }

        public IActionResult Update(int id)
        {
            var item = _courseStudentRepository.GetAll().Where(x => x.CourseStudentID == id).Single();
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(CourseStudent courseStudentObj)
        {
            var item = _courseStudentRepository.GetAll().Where(x => x.CourseStudentID == courseStudentObj.CourseStudentID).Single();
            item.CourseID = courseStudentObj.CourseID;
            item.StudentID = courseStudentObj.StudentID;   
            _courseStudentRepository.Update(item);
            return View("Index", _courseStudentRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _courseStudentRepository.GetAll().Where(x => x.CourseStudentID == id).Single();
            return View("Delete", item);
        }

        [HttpPost]
        public IActionResult Delete(CourseStudent courseStudentObj)
        {
            _courseStudentRepository.Delete(courseStudentObj.CourseStudentID);
            return View("Index", _courseStudentRepository.GetAll());
        }
    }
}