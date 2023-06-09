using Microsoft.AspNetCore.Mvc;
using proj_aspmvcado.Models;
using proj_aspmvcado.Services;

namespace proj_aspmvcado.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)//constructor
        {
            _studentService = studentService;
            
        }

        public IActionResult Index() //routing
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentsList()//routing
        {
            List<Students> studentsList = new List<Students>();
            studentsList=_studentService.GetstudentsRecord().ToList();

            return View(studentsList);
        }
    }
}
