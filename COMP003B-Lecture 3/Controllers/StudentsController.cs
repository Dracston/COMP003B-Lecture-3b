using Microsoft.AspNetCore.Mvc;
//TODO: reference Models namespace
using COMP003B_Lecture_3.Controllers;

namespace COMP003B_Lecture_3.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students= new List<StudentsController>();
        //GET: Studets/ 
        public IActionResult Index()
        {
            return View(_students);
        }
    }
}
