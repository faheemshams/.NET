using Microsoft.AspNetCore.Mvc;
using mvc17Aug.Models;
using NuGet.Protocol.Core.Types;

namespace mvc17Aug.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _repository;
        private readonly ILogger _logger;

        public StudentController(IRepository<Student> repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
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
        public IActionResult Add(Student student)
        {
            _repository.Add(student);
            _logger.AddLog(1, "Added student");
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _repository.GetAll().Where(x => x.StudentID == id).Single();
            return View("Delete", student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _repository.Delete(student.StudentID);
            _logger.AddLog(1, "Deleted Student");
            return View("Index", _repository.GetAll());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = _repository.GetAll().Where(x => x.StudentID == id).Single();

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            var item = _repository.GetAll().Where(x => x.StudentID == student.StudentID).Single();
            item.StudentName = student.StudentName;
            item.StudentPhone = student.StudentPhone;
            _repository.Update(item);
            _logger.AddLog(1, "updated Student");
            return View("Index", _repository.GetAll());
        }
    }
}
