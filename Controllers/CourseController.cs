using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {       
        public IActionResult Index()
        {       
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(Student student)
        {
            if(ModelState.IsValid == true)
            {
                Repository.AddStudent(student);
                return View("ConfirmController", student);
            }
            else
            {
                return View(student);
            }
        }

        public IActionResult ConfirmController()
        {
            return View();
        }

        public IActionResult List()
        {
            var students = Repository.Students.Where(i => i.Confirm==true).ToList();
            return View(students);
        }
    }
}
