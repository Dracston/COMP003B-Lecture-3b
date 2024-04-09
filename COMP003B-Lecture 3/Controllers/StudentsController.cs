using Microsoft.AspNetCore.Mvc;
//TODO: reference Models namespace
using COMP003B_Lecture_3.Controllers;

namespace COMP003B_Lecture_3.Controllers
{
    public class StudentsController : Controller
    {
        private static List<StudentsControlle
        //GET: Studets/ 
        public IActionResult Index()
        {
            return View(_students);
        }
    }
}
